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

        gfx.DrawString("Reporte De Las Especialidades del Sistema Academia", titleFont,
            XBrushes.Black, new XRect(0, 20, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

        int yPoint = 60;
        foreach (var especialidad in especialidades)
        {
            gfx.DrawString($"ID: {especialidad.IdEspecialidad}, Descripción: {especialidad.Nombre_Especialidad}",
                font, XBrushes.Black, new XRect(40, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
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
            gfx.DrawString($"ID: {usuario.IdUsuario}, Nombre: {usuario.Nombre_Usuario}, Rol en el sistema: {usuario.Rol}", font, XBrushes.Black, new XRect(40, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;
        }

        document.Save(filePath);
    }

    public void GeneratePersonaReport(IEnumerable<Persona> personas, string filePath)
    {
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Reporte de Personas";

        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont titleFont = new XFont("Verdana", 16, XFontStyleEx.Bold);
        XFont font = new XFont("Verdana", 12);

        gfx.DrawString("Reporte de Personas del Sistema Academia", titleFont, XBrushes.Black, new XRect(0, 20, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

        int yPoint = 60;
        foreach (var persona in personas)
        {
            gfx.DrawString($"ID: {persona.IdPersona}, Nombre: {persona.Nombre}, Apellido: {persona.Apellido}, Mail: {persona.Mail}, Direccion: {persona.Direccion}", font, XBrushes.Black, new XRect(40, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;
        }

        document.Save(filePath);
    }

    public void GenerateMateriasReport(IEnumerable<Materia> materias, string filePath)
    {
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Reporte de Materias";

        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont titleFont = new XFont("Verdana", 16, XFontStyleEx.Bold);
        XFont font = new XFont("Verdana", 12);

        gfx.DrawString("Reporte de Materias del Sistema Academia", titleFont, XBrushes.Black, new XRect(0, 20, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

        int yPoint = 60;
        foreach (var materia in materias)
        {
            gfx.DrawString($" Nombre: {materia.Nombre_Materia}, Horas Semanales: {materia.Hs_Semanales},Horas Anuales: {materia.Hs_Totales}", font, XBrushes.Black, new XRect(40, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
            yPoint += 40;
        }

        document.Save(filePath);
    }
}
