﻿using System;

namespace BizHawk.Bizware.BizwareGL
{
	public interface IGuiRenderer : IDisposable
	{
		/// <summary>
		/// Begins rendering
		/// </summary>
		void Begin();

		void Begin(System.Drawing.Size size);

		/// <summary>
		/// begin rendering, initializing viewport and projections to the given dimensions
		/// </summary>
		/// <param name="yflipped">Whether the matrices should be Y-flipped, for use with render targets</param>
		void Begin(int width, int height, bool yflipped = false);

		/// <summary>
		/// draws the specified Art resource
		/// </summary>
		void Draw(Art art);

		/// <summary>
		/// draws the specified Art resource with the specified offset. This could be tricky if youve applied other rotate or scale transforms first.
		/// </summary>
		void Draw(Art art, OpenTK.Vector2 pos);

		/// <summary>
		/// draws the specified Art resource with the specified offset. This could be tricky if youve applied other rotate or scale transforms first.
		/// </summary>
		void Draw(Art art, float x, float y);

		/// <summary>
		/// draws the specified Art resource with the specified offset, with the specified size. This could be tricky if youve applied other rotate or scale transforms first.
		/// </summary>
		void Draw(Art art, float x, float y, float width, float height);
		void Draw(Texture2d art, float x, float y, float width, float height);


		/// <summary>
		/// draws the specified texture2d resource.
		/// </summary>
		void Draw(Texture2d tex);

		/// <summary>
		/// draws the specified texture2d resource.
		/// </summary>
		void Draw(Texture2d tex, float x, float y);


		/// <summary>
		/// draws the specified Art resource with the given flip flags
		/// </summary>
		void DrawFlipped(Art art, bool xflip, bool yflip);

		/// <summary>
		/// Draws a subrectangle from the provided texture. For advanced users only
		/// </summary>
		void DrawSubrect(Texture2d tex, float x, float y, float w, float h, float u0, float v0, float u1, float v1);

		/// <summary>
		/// Ends rendering
		/// </summary>
		void End();

		/// <summary>
		/// Use this, if you must do something sneaky to openGL without this GuiRenderer knowing.
		/// It might be faster than End and Beginning again, and certainly prettier
		/// </summary>
		void Flush();

		bool IsActive { get; }
		MatrixStack Modelview { get; set; }
		IGL Owner { get; }
		MatrixStack Projection { get; set; }
		void RectFill(float x, float y, float w, float h);
		void SetBlendState(IBlendState rsBlend);

		/// <summary>
		/// Sets the specified corner color (for the gradient effect)
		/// </summary>
		void SetCornerColor(int which, OpenTK.Graphics.Color4 color);

		/// <summary>
		/// Sets all four corner colors at once
		/// </summary>
		void SetCornerColors(OpenTK.Graphics.Color4[] colors);

		/// <summary>
		/// Restores the pipeline to the default
		/// </summary>
		void SetDefaultPipeline();
		void SetModulateColor(System.Drawing.Color color);
		void SetModulateColorWhite();

		/// <summary>
		/// Sets the pipeline for this GuiRenderer to use. We won't keep possession of it.
		/// This pipeline must work in certain ways, which can be discerned by inspecting the built-in one
		/// </summary>
		void SetPipeline(Pipeline pipeline);
	}
}