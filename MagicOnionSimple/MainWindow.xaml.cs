
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using MagicOnion.Client;
using MessagePack;
using MessagePack.Resolvers;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MagicOnionSimple {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindowViewModel ViewModel { get; set; }
        public MainWindow() {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
        }

        private async void FindButton_Click(object sender, RoutedEventArgs e) {

            var channel = GrpcChannel.ForAddress("http://127.0.0.1:5300");
            var timeRange = new Models.Request.TimeRange(ViewModel.StartTime, ViewModel.EndTime);
            var timeRange2 = new Dto.Request.TimeRange(ViewModel.StartTime, ViewModel.EndTime);


            /*=============== Query using protobuf-net method ===============*/

            //Using Grpc Query
            // Replacing the default serializer with a MessagePack
            //（Is this method wrong? Does anyone know how to replace the default serializer）

            //var grpcClient = ClientFactory.Create(
            //    BinderConfiguration.Create(   
            //        new List<MarshallerFactory>() {
            //            new Shared.MessagePackMarshallerFactory()
            //        })
            //    )
            //    .CreateClient<ClientInterface.IEmployeeGrpcService>(channel.CreateCallInvoker());

            //Query using Grpc server interface

            var grpcClient = channel.CreateGrpcService<ServerInterface.IEmployeeGrpcService>();

            var result1 = grpcClient.GetEmployee(timeRange);
            var result2 = await grpcClient.GetEmployeeAsync(timeRange);
            var result3 = grpcClient.GetEmployee(ViewModel.Name);              //Overload method ok
            var result4 = await grpcClient.GetEmployeeAsync(ViewModel.Name);   //Overload method ok

            //Query using Grpc client interface (The backend only implements the ServerInterface-IEmployeeGrpcService interface)

            var grpcClient2 = channel.CreateGrpcService<ClientInterface.IEmployeeGrpcService>();

            //Although the backend uses a server port for implementation, it can still be queried successfully
            var result5 = grpcClient2.GetEmployee(timeRange2);            
            var result6 = await grpcClient2.GetEmployeeAsync(timeRange2);
            //The following two overloaded methods were also successful
            var result7 = grpcClient2.GetEmployee(ViewModel.Name);
            var result8 = await grpcClient2.GetEmployeeAsync(ViewModel.Name);


            /*=============== Query using MagicOnion method ===============*/

            //Successfully querying using the server port
            var magicOnionClient1 = MagicOnionClient.Create<ServerInterface.IEmployeeMagicOnionService>(channel);
            var resultA = await magicOnionClient1.GetEmployee(timeRange);
            var resultB = await magicOnionClient1.GetEmployeeByName(ViewModel.Name);

            //However, MagicOnion encountered an exception while using the client interface,
            // error:
            //（The type initializer for 'MagicOnion.Client.DynamicClient.DynamicClientBuilder`1' threw an exception.）
            var magicOnionClient2 = MagicOnionClient.Create<ClientInterface.IEmployeeMagicOnionService>(channel);

            var resultC = await magicOnionClient2.GetEmployee(timeRange2);
            var resultD = await magicOnionClient2.GetEmployeeByName(ViewModel.Name);

            //Testing whether protobuf net and MagicOnion can use the same interface, the answer is obviously not

            //var client2 = channel.CreateGrpcService<ServerInterface.IEmployeeGrpcAndMagicOnionService>();
            //var resultE = await client2.GetEmployeeAsync(timeRange2);
            //var resultF = await client2.GetEmployeeAsync2(ViewModel.Name);
        }
    }

}
