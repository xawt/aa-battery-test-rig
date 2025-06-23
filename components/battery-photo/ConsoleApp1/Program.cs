// ------------------------------------------------------------
// File: Program.cs
// Description: This program captures video frames from a camera,
//              processes them by resizing, and optionally displays
//              a preview window. The processed image is saved to
//              a specified file path.
// Author: Jarek Pawelczyk
// Date: 19.6.2025
// ------------------------------------------------------------

using System.Diagnostics;
using CommandLine;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace BatteryPhoto
{
    /// <summary>
    /// Represents the command-line options for the application.
    /// </summary>
    class Options
    {
        /// <summary>
        /// Gets or sets the camera ID (integer).
        /// </summary>
        [Option("camera", Required = true, HelpText = "Camera ID (integer).")]
        public required int Camera { get; set; }

        /// <summary>
        /// Gets or sets the input resolution (width and height).
        /// </summary>
        [Option("inputresolution", HelpText = "Input resolution: width then height.", Min = 2, Max = 2, Default = new[] { 1280, 960 })]
        public required IEnumerable<int> InputResolution { get; set; }

        /// <summary>
        /// Gets or sets the output resolution (width and height).
        /// </summary>
        [Option("outputresolution", HelpText = "Output resolution: width then height.", Min = 2, Max = 2, Default = new[] { 640, 480 })]
        public required IEnumerable<int> OutputResolution { get; set; }

        /// <summary>
        /// Gets or sets the path to the image file.
        /// </summary>
        [Option("path", HelpText = "Path to the image file.", Default = "sample.jpg")]
        public required string Path { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show a live preview window.
        /// </summary>
        [Option("preview", HelpText = "If set, show a live preview window.")]
        public required bool Preview { get; set; }
    }

    class Program
    {
        /// <summary>
        /// Entry point of the application. Parses command-line arguments and executes the program logic.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>Exit code (0 for success, 1 for failure).</returns>
        static int Main(string[] args)
        {
            return Parser.Default
                         .ParseArguments<Options>(args)
                         .MapResult(RunWithOptions, errs => 1);
        }

        /// <summary>
        /// Executes the program logic using the parsed command-line options.
        /// </summary>
        /// <param name="opts">Parsed command-line options.</param>
        /// <returns>Exit code (0 for success, 1 for failure).</returns>
        static int RunWithOptions(Options opts)
        {
            // Convert IEnumerable<int> into usable integers for resolutions
            var inRes = new List<int>(opts.InputResolution);
            var outRes = new List<int>(opts.OutputResolution);

            int inWidth = inRes[0];
            int inHeight = inRes[1];
            int outWidth = outRes[0];
            int outHeight = outRes[1];

            Console.WriteLine($"Reading {inWidth}×{inHeight}");
            Console.WriteLine($"Writing {outWidth}×{outHeight}");
            Console.WriteLine($"Path: {opts.Path}");

            // Call the image processing logic
            int error = ProcessImage(opts.Camera, opts.Path, inWidth, inHeight, outWidth, outHeight, opts.Preview);

            return error;
        }

        /// <summary>
        /// Captures video frames, processes them, and optionally displays a preview window.
        /// </summary>
        /// <param name="camera">Camera ID.</param>
        /// <param name="path">Path to save the processed image.</param>
        /// <param name="inWidth">Input resolution width.</param>
        /// <param name="inHeight">Input resolution height.</param>
        /// <param name="outWidth">Output resolution width.</param>
        /// <param name="outHeight">Output resolution height.</param>
        /// <param name="preview">Indicates whether to show a preview window.</param>
        /// <returns>Exit code (0 for success, 1 for failure).</returns>
        static int ProcessImage(int camera, string path, int inWidth, int inHeight, int outWidth, int outHeight, bool preview)
        {
            // Initialize video capture with the specified camera ID
            var capture = new VideoCapture(camera);
            if (!capture.IsOpened)
            {
                Console.WriteLine("Error: Could not open video capture.");
                return 1; // Return 1 for failure
            }

            // Set the input resolution for the video capture
            bool okWidth = capture.Set(CapProp.FrameWidth, inWidth);
            bool okHeight = capture.Set(CapProp.FrameHeight, inHeight);

            // Capture frames for a duration of 2 seconds
            var stopwatch = Stopwatch.StartNew();
            var duration = TimeSpan.FromSeconds(2);
            var frame = new Mat();
            while (stopwatch.Elapsed < duration)
            {
                capture.Read(frame); // Read a frame from the video capture
                if (frame.IsEmpty)
                {
                    Console.WriteLine("Error: Could not read frame.");
                    return 1; // Return 1 for failure
                }
                CvInvoke.WaitKey(30); // Refresh the window
            }

            // Resize the frame to the output resolution
            if (!frame.IsEmpty)
            {
                CvInvoke.Resize(frame, frame, new System.Drawing.Size(outWidth, outHeight), 0, 0, Inter.Linear);
            }
            else
            {
                return 1; // Return 1 for failure if the frame is empty
            }

            // Show the last frame in a preview window if the preview option is enabled
            if (!frame.IsEmpty & preview)
            {
                var image = frame.ToImage<Bgr, byte>();
                CvInvoke.Imshow("Last Frame Preview", image);
                CvInvoke.WaitKey(2000);  // Wait for 2 seconds before closing the window
            }

            // Save the processed image to the specified file path
            if (!frame.IsEmpty)
            {
                CvInvoke.Imwrite(path, frame);
                Console.WriteLine($"Image saved to {path}");
            }
            else
            {
                return 1; // Return 1 for failure if the frame is empty
            }

            return 0; // Return 0 for success
        }
    }
}
