using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.Themes.Metro.Dark;


namespace GLSLx64
{
	/// <summary>
	/// Interaction logic for ExtWindowControl.
	/// </summary>
	public partial class ExtWindowControl : UserControl
	{
		private GeneralSettings compilerSettings = new GeneralSettings();
		private ExtensionsSettings extensionsSettings = new ExtensionsSettings();
		private StagesSettings stagesSettings = new StagesSettings();

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtWindowControl"/> class.
		/// </summary>
		public ExtWindowControl()
		{
			this.InitializeComponent();
			GeneralPropertyGrid.SelectedObject = compilerSettings;
		}

		private void ExtensionsClicked()
		{
			GeneralPropertyGrid.SelectedObject = extensionsSettings;
		}

		private void StagesClicked()
		{
			GeneralPropertyGrid.SelectedObject = stagesSettings;
		}

		private void GeneralClicked()
		{
			GeneralPropertyGrid.SelectedObject = compilerSettings;
		}

		private void GeneralTree_OnSelected(object sender, RoutedEventArgs e)
		{
			GeneralClicked();
		}

		private void ExtensionsTree_OnSelected(object sender, RoutedEventArgs e)
		{
			ExtensionsClicked();
		}

		private void StagesTree_OnSelected(object sender, RoutedEventArgs e)
		{
			StagesClicked();
		}

		private void OKButton_OnClickKButton(object sender, RoutedEventArgs e)
		{
		}
	}
}