﻿using System.ComponentModel;
using System;
using PDFXCoreAPI;

namespace CoreAPIDemo
{
	[Description("7. Pagemarks")]
	class Pagemarks
	{
		[Description("7.1. Add Headers and Footers on pages")]
		static public void AddHeadersAndFootersOnPages(Form1 Parent)
		{
			if (Parent.m_CurDoc == null)
				Document.CreateNewDoc(Parent);

			IAUX_Inst auxInst = Parent.m_pxcInst.GetExtension("AUX");
			IPXC_HeaderAndFooterParams firstHeaderFooter = Parent.m_pxcInst.CreateHeaderAndFooterParams();
			IPXC_Font font = Parent.m_CurDoc.CreateNewFont("Arial", (uint)PXC_CreateFontFlags.CreateFont_Serif, 400);
			IColor color = auxInst.CreateColor(ColorType.ColorType_RGB);
			color.SetRGB(0, 0, 0);
			firstHeaderFooter.Font = font;
			firstHeaderFooter.FillColor = color;
			firstHeaderFooter.LeftHeaderText = "%[Page]";
			firstHeaderFooter.LeftFooterText = "%[Page] from %[Pages]";
			firstHeaderFooter.BottomMargin = 36.0f;
			firstHeaderFooter.TopMargin = 36.0f;
			firstHeaderFooter.RightMargin = 36.0f;
			firstHeaderFooter.LeftMargin = 36.0f;
			firstHeaderFooter.FontSize = 10.0f;
			IBitSet bitSet = auxInst.CreateBitSet(Parent.m_CurDoc.Pages.Count);
			bitSet.Set(0, Parent.m_CurDoc.Pages.Count, true);
			Parent.m_CurDoc.PlaceHeadersAndFooters(bitSet, firstHeaderFooter);

			IPXC_HeaderAndFooterParams secondHeaderFooter = Parent.m_pxcInst.CreateHeaderAndFooterParams();
			font = Parent.m_CurDoc.CreateNewFont("Comic Sans MS", (uint)PXC_CreateFontFlags.CreateFont_Italic, 1000);
			color.SetRGB(0.35f, 0.48f, 0.35f);
			secondHeaderFooter.Font = font;
			secondHeaderFooter.FillColor = color;
			secondHeaderFooter.CenterHeaderText = "%[Date:MM.dd.yyyy] %[Time]";
			secondHeaderFooter.CenterFooterText = "Version %[AppVersion]";
			secondHeaderFooter.BottomMargin = 20.0f;
			secondHeaderFooter.TopMargin = 20.0f;
			secondHeaderFooter.RightMargin = 40.0f;
			secondHeaderFooter.LeftMargin = 40.0f;
			secondHeaderFooter.FontSize = 15.0f;
			Parent.m_CurDoc.PlaceHeadersAndFooters(bitSet, secondHeaderFooter);

			IPXC_HeaderAndFooterParams thirdHeaderFooter = Parent.m_pxcInst.CreateHeaderAndFooterParams(); 
			font = Parent.m_CurDoc.CreateNewFont("Symbol", (uint)PXC_CreateFontFlags.CreateFont_Monospaced, 700);
			color.SetRGB(0.67f, 0.23f, 0.8f);
			thirdHeaderFooter.Font = font;
			thirdHeaderFooter.FillColor = color;
			thirdHeaderFooter.RightHeaderText = "%[Computer]";
			thirdHeaderFooter.RightFooterText = "%[User]";
			thirdHeaderFooter.BottomMargin = 40.0f;
			thirdHeaderFooter.TopMargin = 40.0f;
			thirdHeaderFooter.RightMargin = 20.0f;
			thirdHeaderFooter.LeftMargin = 20.0f;
			thirdHeaderFooter.FontSize = 20.0f;
			Parent.m_CurDoc.PlaceHeadersAndFooters(bitSet, thirdHeaderFooter);
		}

		[Description("7.2. Add Watermarks on page")]
		static public void AddWatermarksOnPage(Form1 Parent)
		{
			if (Parent.m_CurDoc == null)
				Document.CreateNewDoc(Parent);

			IAUX_Inst auxInst = Parent.m_pxcInst.GetExtension("AUX");
			IPXC_WatermarkParams watermark = Parent.m_pxcInst.CreateWatermarkParams();
			IColor fillColor = auxInst.CreateColor(ColorType.ColorType_Gray);
			fillColor.SetRGB(0.7f, 0.7f, 0.7f);
			watermark.Text = "WATERMARK";
			watermark.HAlign = 50;
			watermark.VAlign = 0;
			watermark.FillColor = fillColor;
			watermark.Rotation = -30;
			watermark.FontSize = 200;
			watermark.StrokeWidth = 5.0f;
			IBitSet bitSet = auxInst.CreateBitSet(Parent.m_CurDoc.Pages.Count);
			bitSet.Set(0, Parent.m_CurDoc.Pages.Count, true);
			Parent.m_CurDoc.PlaceWatermark(bitSet, watermark);
			watermark.Text = "";
			watermark.ImageFile = System.Environment.CurrentDirectory + "\\Images\\Editor_welcome.png";
			PXC_Size rect = new PXC_Size();
			rect.cx = 200;
			rect.cy = 400;
			watermark.Rotation = -45;
			watermark.VAlign = 2;
			watermark.set_ImageSize(rect);
			watermark.Flags |= (uint)PXC_WatermarkFlags.WatermarkFlag_PlaceOnBackground;
			watermark.WatermarkType = PXC_WatermarkType.Watermark_Image;
			watermark.Opacity = 50;
			Parent.m_CurDoc.PlaceWatermark(bitSet, watermark);
		}

		[Description("7.3. Add Background on page")]
		static public void AddBackgroundOnPage(Form1 Parent)
		{
			if (Parent.m_CurDoc == null)
				Document.CreateNewDoc(Parent);

			IAUX_Inst auxInst = Parent.m_pxcInst.GetExtension("AUX");
			IPXC_BackgroundParams backgroundParams = Parent.m_pxcInst.CreateBackgroundParams();
			IColor fillColor = auxInst.CreateColor(ColorType.ColorType_RGB);
			fillColor.SetRGB(0.5f, 1.0f, 0.5f);
			IBitSet bitSet = auxInst.CreateBitSet(Parent.m_CurDoc.Pages.Count);
			bitSet.Set(0, Parent.m_CurDoc.Pages.Count, true);
			backgroundParams.FillColor = fillColor;
			backgroundParams.VAlign = 0;
			backgroundParams.HAlign = 2;
			backgroundParams.Scale = 60;
			backgroundParams.Rotation = 45;
			Parent.m_CurDoc.PlaceBackgrounds(bitSet, backgroundParams);

			backgroundParams.BackgroundFile = System.Environment.CurrentDirectory + "\\Images\\Editor_welcome.png";
			backgroundParams.BackgroundPage = 0;
			backgroundParams.VAlign = 2;
			backgroundParams.HAlign = 0;
			backgroundParams.Scale = 60;
			backgroundParams.Rotation = 45;
			backgroundParams.Opacity = 50;
			backgroundParams.BackgroundType = PXC_BackgroundType.Background_Image;
			backgroundParams.Flags |= (uint)PXC_BackgroundFlags.BackgroundFlag_ScaleToPage;
			Parent.m_CurDoc.PlaceBackgrounds(bitSet, backgroundParams);

		}
		//		[Description("7.4. Remove Headers and Footers from page")]
		//		static public void RemoveHeadersAndFooters(Form1 Parent)
		//		{
		//			if (Parent.m_CurDoc == null)
		//				return;
		//			
		//			//Get current page
		//			if (Parent.CurrentPage >= Parent.m_CurDoc.Pages.Count)
		//				return;
		//			
		//			IPXC_Page Page = Parent.m_CurDoc.Pages[Parent.CurrentPage];
		//			IPXC_DocumentProps docProps = Parent.m_CurDoc.Props;
		//			//docProps
		//			//Parent.m_CurDoc.
		//			//Remove all fields from page
		//			IPXC_Content content = Page.GetContent(PXC_ContentAccessMode.CAccessMode_FullClone);
		//			IPXC_ContentItems ContentItems = content.Items;
		//			ContentItems.DeleteItems(0);
		//#warning Remove all of the header and footer from page
		//		}
		//
		//		[Description("7.5. Remove Watermarks from page")]
		//		static public void RemoveWatermarks(Form1 Parent)
		//		{
		//#warning Remove all of the watermarks from page
		//		}
		//
		//		[Description("7.6. Remove Background from page")]
		//		static public void RemoveBackgroundOnPage(Form1 Parent)
		//		{
		//#warning Remove all of the background from page
		//		}
	}
}
