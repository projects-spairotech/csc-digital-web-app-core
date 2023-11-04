using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace csc_digital_web_app.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			string test = string.Empty
			// Load the source image file
			//using (Merger merger = new Merger(@"c:\sample1.jpg"))
			//{
			//	// Define image join options with horizontal join mode
			//	ImageJoinOptions joinOptions = new ImageJoinOptions(ImageJoinMode.Horizontal);
			//	// Add another image file to merge
			//	merger.Join(@"c:\sample2.jpg", joinOptions);
			//	// Define image join options with vertical join mode
			//	joinOptions = new ImageJoinOptions(ImageJoinMode.Vertical);
			//	// Add next image file to merge
			//	merger.Join(@"c:\sample3.jpg", joinOptions);
			//	// Merge image files and save result
			//	merger.Save(@"c:\merged.jpg");
			//}

			//string[] lstbitmap = { @"D:\Asok.kumar\image-test-combine\1.png", @"D:\Asok.kumar\image-test-combine\ads.png" };
			//var bitmap = @"D:\Asok.kumar\image-test-combine\1.png";
			//var bitmap2 = @"D:\Asok.kumar\image-test-combine\ads.png";
			//lstbitmap.Add(bitmap);
			//lstbitmap.Add(bitmap2);
			//CombineBitmap(lstbitmap);
			//var bitmap = GetBitmap(); // The method that returns List<Bitmap>
			//var width = 0;
			//var height = 0;
			//foreach (var image in bitmap)
			//{
			//	width += image.Width;
			//	height = image.Height > height
			//		? image.Height
			//		: height;
			//}
			//var bitmap2 = new Bitmap(width, height);
			//var g = Graphics.FromImage(bitmap2);
			//var localWidth = 0;
			//foreach (var image in bitmap)
			//{
			//	g.DrawImage(image, localWidth, 0);
			//	localWidth += image.Width;
			//}

			//var ms = new MemoryStream();

			//bitmap2.Save(ms, ImageFormat.Png);
			//var result = ms.ToArray();
			////string base64String = Convert.ToBase64String(result); 
			//return File(result, "image/jpeg"); //Return as file result
			//								   //return base64String;
		}

		//this method returns List<Bitmap>
		//public List<Bitmap> GetBitmap()
		//{
		//	var lstbitmap = new List<Bitmap>();
		//	var bitmap = new Bitmap(@"E:\My project\ProjectImage\ProjectImage\BmImage\1525244892128.JPEG");
		//	var bitmap2 = new Bitmap(@"E:\My project\ProjectImage\ProjectImage\BmImage\1525244892204.JPEG");
		//	var bitmap3 = new Bitmap(@"E:\My project\ProjectImage\ProjectImage\BmImage\3.jpg");
		//	lstbitmap.Add(bitmap);
		//	lstbitmap.Add(bitmap2);
		//	lstbitmap.Add(bitmap3);
		//	return lstbitmap;
		//}

		/*public static System.Drawing.Bitmap CombineBitmap(string[] files)
		{
			//read all images into memory
			List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
			System.Drawing.Bitmap finalImage = null;

			try
			{
				int width = 0;
				int height = 0;

				foreach (string image in files)
				{
					//create a Bitmap from the file and add it to the list
					System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);

					//update the size of the final bitmap
					width += bitmap.Width;
					height = bitmap.Height > height ? bitmap.Height : height;

					images.Add(bitmap);
				}

				//create a bitmap to hold the combined image
				finalImage = new System.Drawing.Bitmap(width, height);

				//get a graphics object from the image so we can draw on it
				using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
				{
					//set background color
					g.Clear(System.Drawing.Color.Black);

					//go through each image and draw it on the final image
					int offset = 0;
					foreach (System.Drawing.Bitmap image in images)
					{
						g.DrawImage(image,
						  new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
						offset += image.Width;
					}
				}

				return finalImage;
			}
			catch (Exception ex)
			{
				if (finalImage != null)
					finalImage.Dispose();

				throw ex;
			}
			finally
			{
				//clean up memory
				foreach (System.Drawing.Bitmap image in images)
				{
					image.Dispose();
				}
			}
		}
		*/

	}
}
