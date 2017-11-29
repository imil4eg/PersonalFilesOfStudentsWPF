using Ninject;
using System;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The IoC container of our application
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A short cut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// A shortcut to access the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="AddStudentViewModel"/>
        /// </summary>
        public static AddStudentViewModel AddStudent => IoC.Get<AddStudentViewModel>();

        /// <summary>
        /// A shortcut to acces the <see cref="StudentListDesignModel"/>
        /// </summary>
        public static StudentListDesignModel StudentListDesignModel => IoC.Get<StudentListDesignModel>();

        #endregion

        #region Contruction

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE : Must be called as soon as your application starts up to ensure all
        ///        services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a single instance of Application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            // Bind to a single instance of AddStudent view model
            Kernel.Bind<AddStudentViewModel>().ToConstant(new AddStudentViewModel());

            Kernel.Bind<StudentListDesignModel>().ToConstant(StudentListDesignModel.Instance);
        }

        #endregion

        /// <summary>
        /// Gets a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
