using System;

namespace MagicOnionSimple.Server {

    /// <summary>
    /// Simulate database context for testing
    /// </summary>
    public abstract class DbContextBase {

        public List<Models.Employee> Employees { get; set; } = null!;

    }
}
