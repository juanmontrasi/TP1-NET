using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Collections.Generic;
using proyecto_academia.Context;
using Entidades;

public class ReportGenerator
{
    public void GenerateEspecialidadesReport(IEnumerable<Especialidad> especialidades, string filePath)
    {
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Reporte de Especialidades";

        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont titleFont = new XFont("Verdana", 16, XFontStyleEx.Bold);
        XFont font = new XFont("Verdana", 12);

        gfx.DrawString("Reporte De Las Especialidades del Sistema Academia", titleFont, XBrushes.Black, new XRect(0, 20, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

        int yPoint = 60;
        foreach (var especialidad in especialidades)
        {
            gfx.DrawString($"ID: {especialidad.IdEspecialidad}, Descripción: {especialidad.Nombre_Especialidad}", font, XBrushes.Black, new XRect(40, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;
        }

        document.Save(filePath);
    }

    public void GenerateUsuariosReport(IEnumerable<Usuario> usuarios, string filePath)
    {
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Reporte de Usuarios";

        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont titleFont = new XFont("Verdana", 16, XFontStyleEx.Bold);
        XFont font = new XFont("Verdana", 12);

        gfx.DrawString("Reporte de Usuarios del Sistema Academia", titleFont, XBrushes.Black, new XRect(0, 20, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

        int yPoint = 60;
        foreach (var usuario in usuarios)
        {
            gfx.DrawString($"ID: {usuario.IdUsuario}, Nombre: {usuario.Nombre_Usuario}, Rol: {usuario.Rol}, Habilitado: {usuario.Habilitado}", font, XBrushes.Black, new XRect(40, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;
        }

        document.Save(filePath);
    }
}
