using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumTestTool.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SingInAndProductTestMethod()
        {//Web tabanl� sistemlerde testleri yapmak i�in geli�tirilmi� bir test arac�d�r veya k�t�phanedir.

            IWebDriver driver = new FirefoxDriver();//Hangi taray�c� �zerinden i�lem yapaca��m� belirtiyorum.
            string link = @"https://www.n11.com/";
            driver.Navigate().GoToUrl(link);//Url'e gitme i�lemi



            {//Login Test A�amas�
                //Giri� yap butonunun class=btnSignIn bilgisi
                driver.FindElement(By.ClassName("btnSignIn")).Click(); // Butonu clickleyip o sayfaya gidecek

                //Email textbox'�n id=email bilgisi
                driver.FindElement(By.Id("email")).SendKeys("alisarideneme@outlook.com");// SendKesys() komudu ile de�er g�nderilecek

                //�ifre textbox'�n id=password bilgisi
                driver.FindElement(By.Id("password")).SendKeys("258963ali");// SendKesys() komudu ile de�er g�nderilecek

                // �ye giri�i yapmak i�in butonun id=loginButton bilgisi
                driver.FindElement(By.Id("loginButton")).Click();// Id bilgisi varsa onu kullanal�m class bilgisi birden �ok yerde kullan�labiliniyor.
            }

            Thread.Sleep(2000);

            // Arama textbox'�n      id=searchData   bilgisi
            driver.FindElement(By.Id("searchData")).SendKeys("Samsung"); // Samsung verilerini ar�yorum

            // Arama Butonun      class=searchBtn  bilgisi
            driver.FindElement(By.ClassName("searchBtn")).Click();


            // Normalde sadece class bilgisi varsa onu verebilirim fakat bazen sayfalar�m�zda class veya id bilgisi verilmeye bilir o y�zden ad�m ad�m bak�yorum. Alt div'e nas�l ge�ilir
            // 2. sayfaya ge�mek i�in �ncelikle t�m sayfan�n oldu�u div laz�m   id=contentListing    bilgisi 
            // Sonras�nda alt�nda bir div var o divin i�ersine giriyoruz
            // Tekrar bak�yoruz ka� div var tek div oldu�u i�in 
            // ��inde 2 farkl� div var biz sa�daki divi al�caz. Birden fazla oldu�u i�in [2] dizi �eklinde hangisi ise se�meliyiz �eklinde devam ederiz

            // Veya bu ad�mlar� yapmak yerine  direk istedi�imiz mesela ikinci sayfa butonunu inceleyerek Copy XPath yapabliriz
            // fakat "contentListing" yerine 'contentListing' yaz�lmas� gerekir yani tek t�rnak

            // SAYFA NUMARASI 2 OLAN BUTON'UN XPATH'I LAZIM
            //*[@id="contentListing"]/div/div/div[2]/div[4]/a[2]
            //                          b�t�n sayfa i�ersinde id=contentListing bul alt�ndaki div'e gir
            driver.FindElement(By.XPath("//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]")).Click(); // XPath b�t�n sayfa i�inde arama yapan bir c�mlecik


            // Rasgele bir �r�n se�iyorum o �r�ne ait en ba�taki div i�in id=p-530088692 bilgisi a link bilgisinin XPath olarak kopyalarsam unutmayay�m Tek T�rnak ve arada bo�luk yok visual kendi otomatik at�yor d�zelt
            driver.FindElement(By.XPath("//*[@id='p-489569060']/div[1]/a")).Click();
           
            Thread.Sleep(5000);//Bekleme s�resi koyuyyorum sayfa y�klensin yoksa patl�yor


            // Detaylar� g�rmek i�in class=detailPreviewBtn
            driver.FindElement(By.ClassName("detailPreviewBtn")).Click();

            Thread.Sleep(1000);

            // Detaylar� kapatmak i�in class=btnOk
            driver.FindElement(By.ClassName("btnOk")).Click();

            Thread.Sleep(2000);

            // Adetini 1 tane artt�rmak i�in buton bilgisi XPath hali
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[1]/div[1]/div[2]/form/div[2]/div[2]/div[1]/div/div/span[1]")).Click();

            // Sepete eklemek i�in buton bilgisi class=addBasketUnify
            driver.FindElement(By.ClassName("addBasketUnify")).Click();

            Thread.Sleep(1000);

            // Sepette adeti olmayan �r�n hata mesaj�n� kapatma XPath
            driver.FindElement(By.ClassName("confirm")).Click();

            Thread.Sleep(1000);

            // Sepete ekledi�im �r�n adetini azaltma class=spinnerDown 
            driver.FindElement(By.ClassName("spinnerDown")).Click();

            // Sepete eklemek i�in buton bilgisi class=addBasketUnify
            driver.FindElement(By.ClassName("addBasketUnify")).Click();

            Thread.Sleep(2000);

            // Sepete Gitmek i�in buton bilgisi class=btnGoBasket
            driver.FindElement(By.ClassName("btnGoBasket")).Click();


            // Kar��ma ��kan Ayd�tlatma Metnini kapatmak i�in XPath
            // Ayd�nlatma metni kullan�c� giri� yapmad�ysa ��kar
            //driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/span")).Click();

            Thread.Sleep(2000);

            // Sepetteki �r�n� silmek i�in class=removeProd 
            driver.FindElement(By.ClassName("removeProd")).Click();

            Thread.Sleep(5000);

            // Anasayfaya D�nmek i�in class=home 
            driver.FindElement(By.XPath("/html/body/div[1]/header/div/a")).Click();

            //Thread.Sleep(9000);

            // En son kullan�c� hesab�mdan ��k�� yapmak i�in class=logoutBtn
            //driver.FindElement(By.ClassName("logoutBtn")).Click();


        }
    }
}
