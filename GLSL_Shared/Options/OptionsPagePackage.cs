﻿using DMS.GLSL.Contracts;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.GLSL.Options
{
	/// <summary>
	/// This is the class that implements the package exposed by this assembly.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The minimum requirement for a class to be considered a valid package for Visual Studio
	/// is to implement the IVsPackage interface and register itself with the shell.
	/// This package uses the helper classes defined inside the Managed Package Framework (MPF)
	/// to do it: it derives from the Package class that provides the implementation of the
	/// IVsPackage interface and uses the registration attributes defined in the framework to
	/// register itself and its components with the shell. These attributes tell the pkgdef creation
	/// utility what data to put into .pkgdef file.
	/// </para>
	/// <para>
	/// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
	/// </para>
	/// </remarks>
	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
	[Guid(PackageGuidString)]
	[ProvideOptionPage(typeof(OptionPage), "GLSL language integration", "Configuration", 0, 0, true)]
	[ProvideMenuResource("Menus.ctmenu", 1)]
	[ProvideToolWindow(typeof(GLSLx64.ExtWindow))]
	public sealed class OptionsPagePackage : AsyncPackage
	{
		private const string PackageGuidString = "fd8ee466-e18c-45fc-b1a1-ca0dc1ec67fb";

		[Export(typeof(ICompilerSettings))]
		[Export(typeof(IShaderStages))]
		[Export(typeof(IShaderFileExtensions))]
		[Export(typeof(IUserKeywords))]
		public OptionPage Options => _options ?? (_options = Load() ?? new OptionPage());

		public static OptionPage Load()
		{
			var joinableTaskFactory = ThreadHelper.JoinableTaskFactory;
			return joinableTaskFactory.Run(LoadAsync);
		}

		public static async System.Threading.Tasks.Task<OptionPage> LoadAsync()
		{
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
			lock (_syncRoot)
			{
				var shell = (IVsShell)GetGlobalService(typeof(SVsShell));
				var guid = new Guid(PackageGuidString);
				if (ErrorHandler.Failed(shell.IsPackageLoaded(ref guid, out IVsPackage package)))
				{
					if (ErrorHandler.Failed(shell.LoadPackage(ref guid, out package))) return null;
				}
				var myPack = package as OptionsPagePackage;
				return (OptionPage)myPack.GetDialogPage(typeof(OptionPage));
			}
		}

		private OptionPage _options;
		private static readonly object _syncRoot = new object();

	    /// <summary>
	    /// Initialization of the package; this method is called right after the package is sited, so this is the place
	    /// where you can put all the initialization code that rely on services provided by VisualStudio.
	    /// </summary>
	    /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
	    /// <param name="progress">A provider for progress updates.</param>
	    /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
	    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
	    {
	        await base.InitializeAsync(cancellationToken, progress);
	    
	        // When initialized asynchronously, the current thread may be a background thread at this point.
	        // Do any initialization that requires the UI thread after switching to the UI thread.
	        await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
	        await GLSLx64.KEditSettings.InitializeAsync(this);
	        await GLSLx64.ExtWindowCommand.InitializeAsync(this);
	    }
	}
}
