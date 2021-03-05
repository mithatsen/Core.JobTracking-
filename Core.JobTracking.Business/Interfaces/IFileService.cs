using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JobTracking.Business.Interfaces
{
    public interface IFileService
    {
        
        //Geriye üretmiş ve upload etmiş olduğu pdf dosyasının virtual pathi döner
        string TransferPdf<T>(List<T> list) where T :class,new();

        //Geriye excel verisini byte dizisi olarak döner
        byte[] TransferExcel<T>(List<T> list) where T : class, new();



            
    }
}
