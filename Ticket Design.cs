using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace DM_Main
{
    public partial class Ticket_Design : Form
    {
        static string advertText = "This is A Multiline \nAdvertisment space",
            companyURL = "www.example.com",additionalText = "Thanks for visit \n For any querries contact Manager";
        string sampleTokenNum = null, operaName = null;
        
        bool tokTemplate = false;
        string imgPath = null;
        PrintDocument pdoc = null;
        public Ticket_Design()
        {
            InitializeComponent();
            
            openDialogCompanyLogo.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
        }
        public void setTokenValue(string str)
        {
            sampleTokenNum = str;

        }

        public void setOperationName(string str)
        {
            operaName = str;
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openDialogCompanyLogo.ShowDialog();
            
            if (result == DialogResult.OK) // Test result.
            {
                imgPath = openDialogCompanyLogo.FileName;
               // MessageBox.Show("Path = " + imgPath);
            }
            //System.Diagnostics.Debug.WriteLine(result); // <-- For debugging use.
        }

        public void print()
        {
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);


            PaperSize psize = new PaperSize("Custom", 100, 200);
            //ps.DefaultPageSettings.PaperSize = psize;

            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height =320;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;

            pdoc.DefaultPageSettings.PaperSize.Width = 520;

            pdoc.PrintPage += new PrintPageEventHandler(viewImage);

            //pdoc.Print();
            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
                result = pp.ShowDialog();
                //MessageBox.Show("Print result: " + result.ToString());
                if (result == DialogResult.OK)
                {
                    pdoc.Print();
                }
            }
            

        }
        // preview token ticket in a picturebox on screen
        void viewImage(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int width = TicketDesignView_picturebox.Size.Width;
            int height = TicketDesignView_picturebox.Size.Height;
           // MessageBox.Show("Width = " + width.ToString()+ "Height = "+height.ToString());
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            
            Pen blackPen = new Pen(Color.Black, 3);
            

            int startX = width/2;
            int startY = 0;
            int Offset = 30;
            
            
            graphics.DrawString("This is Preview of Token Print", new Font("Courier New", 9),
                                new SolidBrush(Color.Black), startX, startY + Offset,format);
            Offset = Offset + 20;
            if (advertText.Contains('\n'))
            {
                string[] splitadvert = advertText.Split('\n');
                foreach (string str in splitadvert)
                {
                    graphics.DrawString(str.ToUpper(), new Font("Courier New",18, FontStyle.Bold),
                           new SolidBrush(Color.Black), startX, startY + Offset, format);
                    Offset += 20;
                }
            }
            else
            {
                graphics.DrawString(advertText.ToUpper(),
                     new Font("Courier New", 18, FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);

            }
           /* graphics.DrawString(advertText,
                     new Font("Courier New", 20,FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset,format);*/
           
            if (imgPath != null)
            {

                Bitmap image = new Bitmap(imgPath);
                Offset = Offset + 20;
                graphics.DrawImage(image, new Rectangle(100, startY + 60, image.Width, image.Height));
                //graphics.DrawRectangle(blackPen, new Rectangle(100, startY + 60, image.Width, image.Height));
                Offset = Offset + image.Height+5;
            }
            else
            {
                Bitmap image = new Bitmap(pictureBox_Logo.Image);
                //MessageBox.Show("no image found__elseeeeeeeeeee");
                Offset = Offset + 20;
                graphics.DrawImage(image, new Rectangle(100, startY + 60, image.Width, image.Height));
                //graphics.DrawRectangle(Pens.Blue, new Rectangle(100, startY + 60, image.Width, image.Height));
                Offset = Offset + image.Height+5;
                
               
            }

            
            graphics.DrawString( companyURL,
                     new Font("Courier New", 12),
                     new SolidBrush(Color.Blue), startX, startY + Offset, format);
            Offset = Offset + 10;
           // MessageBox.Show("offset:" + Offset.ToString());
            String underLine = "---------------------------------------------------------------------";
            //Point point1 = new Point(Offset, Offset+110);
            //Point point2 = new Point(Offset+500, Offset+110);
            //graphics.DrawLine(blackPen, point1,point2);
            graphics.DrawString(underLine, new Font("Courier New", 10),
                     new SolidBrush(Color.Black), 10, startY + Offset);

            Offset = Offset +20;
            //String Source = "Operation1";
            graphics.DrawString(operaName , new Font("Courier New", 14,FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);

            Offset = Offset + 30;

            String tokLabel = "Token Number";
            graphics.DrawString(tokLabel, new Font("Courier New", 14),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);
            Offset = Offset + 30;
            //String tokNum = "A601";
            graphics.DrawString(sampleTokenNum, new Font("Courier New", 28,FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);
            Offset = Offset + 50;
            String RegDate = "Registered Date ";
            RegDate += DateTime.Now.ToString("MMM/dd/yyyy");
            RegDate += " And Time ";
            RegDate += DateTime.Now.ToString("HH:mm:ss"); ;
            graphics.DrawString(RegDate, new Font("Courier New", 10, FontStyle.Italic),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);
            //string additionalText = "Here it goes Additional Text \n"+textBox_AddtionalText.Text;
            Offset += 11;
            if (additionalText.Contains('\n'))
            {
                string[] splitStr = additionalText.Split('\n');
                foreach (string str in splitStr)
                {
                    
                    graphics.DrawString(str, new Font("Courier New", 10, FontStyle.Italic),
                             new SolidBrush(Color.Black), startX, startY + Offset, format);
                    Offset += 11;
                }
            }
            else
            {
                graphics.DrawString(additionalText, new Font("Courier New", 10, FontStyle.Italic),
                         new SolidBrush(Color.Black), startX, startY + Offset, format);
            }
            
            
        }
        // Print Token ticket using default printer
        void viewImage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int width = TicketDesignView_picturebox.Size.Width;
            int height = TicketDesignView_picturebox.Size.Height;
            // MessageBox.Show("Width = " + width.ToString()+ "Height = "+height.ToString());
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            Pen blackPen = new Pen(Color.Black, 3);


            int startX = width / 2;
            int startY = 0;
            int Offset = 30;
            if (advertText.Contains('\n'))
            {
                string[] splitadvert = advertText.Split('\n');
                foreach (string str in splitadvert)
                {
                    graphics.DrawString(str.ToUpper(),new Font("Courier New", 18, FontStyle.Bold),
                           new SolidBrush(Color.Black), startX, startY + Offset, format);
                    Offset += 20;
                }
            }
            else
            {
                graphics.DrawString(advertText.ToUpper(),
                     new Font("Courier New", 18, FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);
                Offset += 20;
            }

            /*graphics.DrawString(advertText,
                     new Font("Courier New", 20, FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);*/
            
            if (imgPath != null)
            {
                Bitmap image = new Bitmap(imgPath);
                Offset = Offset + 20;
                graphics.DrawImage(image, new Rectangle(100, startY + 60, image.Width, image.Height));
                Offset = Offset + image.Height+5;
            }
            else
            {
                Bitmap image = new Bitmap(pictureBox_Logo.Image);
                Offset = Offset + 20;
                graphics.DrawImage(image, new Rectangle(100, startY + 60, image.Width, image.Height));
                Offset = Offset + image.Height + 5;
             
            }


            graphics.DrawString(companyURL,
                     new Font("Courier New", 12),
                     new SolidBrush(Color.Blue), startX, startY + Offset, format);
            Offset = Offset + 10;
//            MessageBox.Show("offset:" + Offset.ToString());
            String underLine = "---------------------------------------------------------------------";
            //Point point1 = new Point(Offset, Offset+110);
            //Point point2 = new Point(Offset+500, Offset+110);
            //graphics.DrawLine(blackPen, point1,point2);
            graphics.DrawString(underLine, new Font("Courier New", 10),
                     new SolidBrush(Color.Black), 10, startY + Offset);

            Offset = Offset + 40;
           // String Source = "Operation1";
            graphics.DrawString(operaName, new Font("Courier New", 14, FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);

            Offset = Offset + 30;

            String tokLabel = "Token Number";
            graphics.DrawString(tokLabel, new Font("Courier New", 14),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);
            Offset = Offset + 30;
            
            graphics.DrawString(sampleTokenNum, new Font("Courier New", 28, FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);
            Offset = Offset + 50;
            String RegDate = "Registered Date ";
            RegDate += DateTime.Now.ToString("MMM/dd/yyyy");
            RegDate += " And Time ";
            RegDate += DateTime.Now.ToString("HH:mm:ss"); ;
            graphics.DrawString(RegDate, new Font("Courier New", 10, FontStyle.Italic),
                     new SolidBrush(Color.Black), startX, startY + Offset, format);
            //string additionalText = "Here it goes Additional Text \n" + textBox_AddtionalText.Text;
            
            Offset += 20;
            if (additionalText.Contains('\n'))
            {
                string[] splitStr = additionalText.Split('\n');
                foreach (string str in splitStr)
                {
                    graphics.DrawString(str, new Font("Courier New", 10, FontStyle.Italic),
                             new SolidBrush(Color.Black), startX, startY + Offset, format);
                    Offset += 11;
                }
            }
            else
            {
                graphics.DrawString(additionalText, new Font("Courier New", 10, FontStyle.Italic),
                         new SolidBrush(Color.Black), startX, startY + Offset, format);
            }

        }
        
        
        private void btnPreviewTokenTemplate_Click(object sender, EventArgs e)
        {
            advertText = tbAdvert_Text.Text;
            companyURL = companyWesiteLink_textbox.Text;
            additionalText = textBox_AddtionalText.Text;
            operaName = "Selected Operation Name";
            sampleTokenNum = "A601";

            tokTemplate = true;
            this.Refresh();
        }

        private void TicketDesignView_picturebox_Paint(object sender, PaintEventArgs e)
        {
            if (tokTemplate)
            {
                viewImage(sender, e);
            }
        }

        private void btnPrintSampleToken_Click(object sender, EventArgs e)
        {
            print();
        }
        
     
    }
}
