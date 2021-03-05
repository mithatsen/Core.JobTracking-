using Core.JobTracking.Business.Interfaces;
using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

using System.Text;

namespace Core.JobTracking.Business.Concrete
{
    public class FileManager : IFileService
    {


        public byte[] TransferExcel<T>(List<T> list) where T : class, new()
        {
            var excel = new ExcelPackage();  // elimizde bir paket var
            var excelBlank = excel.Workbook.Worksheets.Add("Calisma1"); //Çalışma1 adında sayfa oluştu
            excelBlank.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light15);  // burda true yazan yer başlıkolmasını sağlar
            return excel.GetAsByteArray();
        }

        public string TransferPdf<T>(List<T> list) where T : class, new()
        {

            DataTable dataTable = new DataTable();
            dataTable.Load(ObjectReader.Create(list)); //package ekletiyor

            string fileName = Guid.NewGuid() + ".pdf";
            string returnPath = "/documents/" + fileName;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);
            var stream = new FileStream(path, FileMode.Create);


            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f); // her taraftanboşluk 25f
            PdfWriter.GetInstance(document, stream);


            document.Open();

            PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count); //sütun syaısını vermeliyiz

            for (int i = 0; i < dataTable.Columns.Count; i++) //ilk başlık satırı için gerekli yer
            {
                pdfTable.AddCell(dataTable.Columns[i].ColumnName);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfTable.AddCell(dataTable.Rows[i][j].ToString());
                }
            }
            document.Add(pdfTable);
            document.Close();

            return returnPath;
        }
    }
}
