using System.Collections.Generic;
using System.IO;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;

namespace Palmmedia.ReportGenerator.Core.Reporting.Builders
{
    /// <summary>
    /// Creates report in HTML format.
    /// </summary>
    public class HtmlBlueRedReportBuilder : HtmlReportBuilderBase
    {
        /// <summary>
        /// Defines how CSS and JavaScript are referenced.
        /// </summary>
        private readonly HtmlMode htmlMode;

        /// <summary>
        /// Dictionary containing the filenames of the class reports by class.
        /// </summary>
        private readonly IDictionary<string, string> fileNameByClass = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBlueRedReportBuilder" /> class.
        /// </summary>
        public HtmlBlueRedReportBuilder()
            : this(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBlueRedReportBuilder" /> class.
        /// </summary>
        /// <param name="externalCssAndJavaScriptWithQueryStringHandling">Defines how CSS and JavaScript are referenced.</param>
        public HtmlBlueRedReportBuilder(bool externalCssAndJavaScriptWithQueryStringHandling)
        {
            this.htmlMode = externalCssAndJavaScriptWithQueryStringHandling ? HtmlMode.ExternalCssAndJavaScriptWithQueryStringHandling
                : HtmlMode.ExternalCssAndJavaScript;
        }

        /// <summary>
        /// Gets the report type.
        /// </summary>
        /// <value>
        /// The report format.
        /// </value>
        public override string ReportType => "Html_BlueRed";

        /// <summary>
        /// Creates a class report.
        /// </summary>
        /// <param name="class">The class.</param>
        /// <param name="fileAnalyses">The file analyses that correspond to the class.</param>
        public override void CreateClassReport(Class @class, IEnumerable<FileAnalysis> fileAnalyses)
        {
            using (var renderer = new HtmlRenderer(this.fileNameByClass, false, this.htmlMode, new string[] { "custom_adaptive.css", "custom_bluered.css" }, "custom.css"))
            {
                this.CreateClassReport(renderer, @class, fileAnalyses);
            }
        }

        /// <summary>
        /// Creates the summary report.
        /// </summary>
        /// <param name="summaryResult">The summary result.</param>
        public override void CreateSummaryReport(SummaryResult summaryResult)
        {
            using (var renderer = new HtmlRenderer(this.fileNameByClass, false, this.htmlMode, new string[] { "custom_adaptive.css", "custom_bluered.css" }, "custom.css"))
            {
                this.CreateSummaryReport(renderer, summaryResult);
            }

            string targetDirectory = this.CreateTargetDirectory();

            File.Copy(
                Path.Combine(targetDirectory, "index.html"),
                Path.Combine(targetDirectory, "index.htm"),
                true);
        }
    }
}
Fix API - fixing a bugOptimize database - enhancing logs