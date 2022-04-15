﻿using DMS.GLSL.Contracts;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace DMS.GLSL.Options
{
	[ComVisible(true)]
	public partial class OptionPage : DialogPage, ICompilerSettings, IUserKeywords
	{
		private string _userKeyWords1;
		private string _userKeyWords2;

		[Category("General")]
		[DisplayName("Arguments for the external compiler executable")]
		[Description("Command line arguments for the external compiler executable. Can contain environment variables, like %USERPROFILE% and also the Visual Studio variable $(SolutionDir). A single argument that includes spaces must be surrounded by quotation marks, but those quotation marks are not carried through to the target application. In include quotation marks in the final parsed argument, triple-escape each mark.")]
		public string ExternalCompilerArguments { get; set; } = string.Empty;

		[Category("General")]
		[DisplayName("External compiler executable file path (without quotes)")]
		[Description("If non empty this file will be executed for each shader and the output parsed for error squiggles. Can contain environment variables, like % USERPROFILE % and also the Visual Studio variable $(SolutionDir).")]
		public string ExternalCompilerExeFilePath { get; set; } = string.Empty;

		[Category("General")]
		[DisplayName("Live compiling")]
		[Description("Compile the shader code in the background and show resulting errors")]
		public bool LiveCompiling { get; set; } = true;

		[Category("General")]
		[DisplayName("Expand includes")]
		[Description("Expand includes to support shader compilers which do not support the #include pragma. This option only works if include paths are absolute or relative to the current file")]
		public bool ExpandIncludes { get; set; } = true;

		[Category("General")]
		[DisplayName("User key words 1")]
		[Description("Space separated list of user key words (used for coloring)")]
		public string UserKeyWords1
		{
			get => _userKeyWords1;
			set
			{
				_userKeyWords1 = value;
				userKeywordArray1 = ParseWords(value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(userKeywordArray1)));
			}
		}

		[Category("General")]
		[DisplayName("User key words 2")]
		[Description("Space separated list of user key words (used for coloring)")]
		public string UserKeyWords2
		{
			get => _userKeyWords2;
			set
			{
				_userKeyWords2 = value;
				userKeywordArray2 = ParseWords(value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(userKeywordArray2)));
			}
		}

		[Category("General")]
		[DisplayName("Compile delay(ms)")]
		[Description("Minimal delay between two compiles.")]
		public int CompileDelay { get; set; } = 200;

		[Category("General")]
		[DisplayName("Print shader log")]
		[Description("Print the log of the shader compiler into the output pane and the log file")]
		public bool PrintShaderCompilerLog { get; set; } = true;

		public event PropertyChangedEventHandler PropertyChanged;

		IEnumerable<string> IUserKeywords.UserKeywordArray1 => userKeywordArray1;
		IEnumerable<string> IUserKeywords.UserKeywordArray2 => userKeywordArray2;

		private IEnumerable<string> userKeywordArray2 = Enumerable.Empty<string>();
		private IEnumerable<string> userKeywordArray1 = Enumerable.Empty<string>();

		private static string[] ParseWords(string words)
		{
			char[] blanks = { ' ' };
			return words.Split(blanks, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}
