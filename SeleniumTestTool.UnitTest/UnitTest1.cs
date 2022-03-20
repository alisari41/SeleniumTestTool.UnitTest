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
        {//Web tabanlý sistemlerde testleri yapmak için geliþtirilmiþ bir test aracýdýr veya kütüphanedir.

            IWebDriver driver = new FirefoxDriver();//Hangi tarayýcý üzerinden iþlem yapacaðýmý belirtiyorum.
            string link = @"https://www.n11.com/";
            driver.Navigate().GoToUrl(link);//Url'e gitme iþlemi



            {//Login Test Aþamasý
                //Giriþ yap butonunun class=btnSignIn bilgisi
                driver.FindElement(By.ClassName("btnSignIn")).Click(); // Butonu clickleyip o sayfaya gidecek

                //Email textbox'ýn id=email bilgisi
                driver.FindElement(By.Id("email")).SendKeys("alisarideneme@outlook.com");// SendKesys() komudu ile deðer gönderilecek

                //Þifre textbox'ýn id=password bilgisi
                driver.FindElement(By.Id("password")).SendKeys("258963ali");// SendKesys() komudu ile deðer gönderilecek

                // Üye giriþi yapmak için butonun id=loginButton bilgisi
                driver.FindElement(By.Id("loginButton")).Click();// Id bilgisi varsa onu kullanalým class bilgisi birden çok yerde kullanýlabiliniyor.
            }

            Thread.Sleep(2000);

            // Arama textbox'ýn      id=searchData   bilgisi
            driver.FindElement(By.Id("searchData")).SendKeys("Samsung"); // Samsung verilerini arýyorum

            // Arama Butonun      class=searchBtn  bilgisi
            driver.FindElement(By.ClassName("searchBtn")).Click();


            // Normalde sadece class bilgisi varsa onu verebilirim fakat bazen sayfalarýmýzda class veya id bilgisi verilmeye bilir o yüzden adým adým bakýyorum. Alt div'e nasýl geçilir
            // 2. sayfaya geçmek için öncelikle tüm sayfanýn olduðu div lazým   id=contentListing    bilgisi 
            // Sonrasýnda altýnda bir div var o divin içersine giriyoruz
            // Tekrar bakýyoruz kaç div var tek div olduðu için 
            // Ýçinde 2 farklý div var biz saðdaki divi alýcaz. Birden fazla olduðu için [2] dizi þeklinde hangisi ise seçmeliyiz þeklinde devam ederiz

            // Veya bu adýmlarý yapmak yerine  direk istediðimiz mesela ikinci sayfa butonunu inceleyerek Copy XPath yapabliriz
            // fakat "contentListing" yerine 'contentListing' yazýlmasý gerekir yani tek týrnak

            // SAYFA NUMARASI 2 OLAN BUTON'UN XPATH'I LAZIM
            //*[@id="contentListing"]/div/div/div[2]/div[4]/a[2]
            //                          bütün sayfa içersinde id=contentListing bul altýndaki div'e gir
            driver.FindElement(By.XPath("//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]")).Click(); // XPath bütün sayfa içinde arama yapan bir cümlecik


            // Rasgele bir ürün seçiyorum o ürüne ait en baþtaki div için id=p-530088692 bilgisi a link bilgisinin XPath olarak kopyalarsam unutmayayým Tek Týrnak ve arada boþluk yok visual kendi otomatik atýyor düzelt
            driver.FindElement(By.XPath("//*[@id='p-489569060']/div[1]/a")).Click();
           
            Thread.Sleep(5000);//Bekleme süresi koyuyyorum sayfa yüklensin yoksa patlýyor


            // Detaylarý görmek için class=detailPreviewBtn
            driver.FindElement(By.ClassName("detailPreviewBtn")).Click();

            Thread.Sleep(1000);

            // Detaylarý kapatmak için class=btnOk
            driver.FindElement(By.ClassName("btnOk")).Click();

            Thread.Sleep(2000);

            // Adetini 1 tane arttýrmak için buton bilgisi XPath hali
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div[1]/div[1]/div[2]/form/div[2]/div[2]/div[1]/div/div/span[1]")).Click();

            // Sepete eklemek için buton bilgisi class=addBasketUnify
            driver.FindElement(By.ClassName("addBasketUnify")).Click();

            Thread.Sleep(1000);

            // Sepette adeti olmayan ürün hata mesajýný kapatma XPath
            driver.FindElement(By.ClassName("confirm")).Click();

            Thread.Sleep(1000);

            // Sepete eklediðim ürün adetini azaltma class=spinnerDown 
            driver.FindElement(By.ClassName("spinnerDown")).Click();

            // Sepete eklemek için buton bilgisi class=addBasketUnify
            driver.FindElement(By.ClassName("addBasketUnify")).Click();

            Thread.Sleep(2000);

            // Sepete Gitmek için buton bilgisi class=btnGoBasket
            driver.FindElement(By.ClassName("btnGoBasket")).Click();


            // Karþýma çýkan Aydýtlatma Metnini kapatmak için XPath
            // Aydýnlatma metni kullanýcý giriþ yapmadýysa çýkar
            //driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/span")).Click();

            Thread.Sleep(2000);

            // Sepetteki Ürünü silmek için class=removeProd 
            driver.FindElement(By.ClassName("removeProd")).Click();

            Thread.Sleep(5000);

            // Anasayfaya Dönmek için class=home 
            driver.FindElement(By.XPath("/html/body/div[1]/header/div/a")).Click();

            //Thread.Sleep(9000);

            // En son kullanýcý hesabýmdan çýkýþ yapmak için class=logoutBtn
            //driver.FindElement(By.ClassName("logoutBtn")).Click();


        }
    }
}
