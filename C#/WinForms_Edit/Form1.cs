using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Edit
{
    public partial class Form1 : Form
    {
        int textChanged = 0;    // 텍스트 변경 여부를 확인하는 변수입니다.

        public Form1()
        {
            InitializeComponent();
        }

        // Form1이 로드 되었을 때 실행됩니다.
        private void Form1_Load(object sender, EventArgs e)
        {
            setFontInfo();
        }
        
        // Form1이 활성화되었을 때 실행됩니다.  
        private void Form1_Activated(object sender, EventArgs e)
        {

        }



        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            // C++에서의 DoModal() 메서드와 동일한 기능을 가지고 있습니다.
            // DialogResult 타입 변수에 ShowDialog의 리턴값을 대입합니다. (OK or Cancel)
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            // dialogResult의 값을 DialogResult Enum의 상수값 OK와 비교합니다.
            if (dialogResult == DialogResult.OK)
            {
                // OpenFileDialog.FileName은 선택한 파일의 전체 경로를 리턴합니다.
                string filePath = openFileDialog1.FileName;

                // 불러온 파일의 이름을 form1의 텍스트로 설정합니다.
                /*
                string[] filePaths = filePath.Split('\\');          // 전체 경로를 '\\'를 기준으로 분할하여 배열에 대입합니다.
                int filePathsLength = filePaths.Length;             // 배열의 길이를 변수에 저장합니다.
                string fileName = filePaths[filePathsLength - 1];   // 배열의 가장 마지막 요소(파일명+확장자)를 변수에 대입합니다.
                this.Text = fileName + " - MyEditor";               // '파일명 + 확장자' + ' - MyEditor'를 form의 Text에 대입합니다.
                */
                // this.Text += $"   [{fileName}]"; 
                // OpenfileDialog.safeFileName; 변수는 파일 명을 리턴합니다.

                // getToken() 메서드 활용
                int tokensLength = MyLib.countToken('\\', filePath);
                string fileName = MyLib.getToken(tokensLength, '\\', filePath);
                this.Text = fileName + " - MyEditor";

                // StreamReader = 특정 인코딩의 바이트 스트림에서 문자를 읽는 TextReader 를 구현합니다.
                // C언어의 FILE*, C++의 CFile과 대응되는 클래스 입니다.
                StreamReader streamReader = new StreamReader(filePath);
                string buffer = streamReader.ReadToEnd();
                streamReader.Close();
                tbMemo.Text = buffer;
            }
        }

        // save As...
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string buffer = tbMemo.Text;
                string savePath = saveFileDialog1.FileName;
                StreamWriter streamWriter = new StreamWriter(savePath);
                streamWriter.Write(buffer);
                streamWriter.Close();
            }
        }

        // 1. file open 후 Memo 창에 표시한 경우 - 확인 (o), 수정(x)
        // 2. New 메뉴 선택 후 문서 편집 - 기존 파일명 없음
        // 3. 기존 문서 중 일부 수정 - 기존 파일명 있음
        private void tbMemo_TextChanged(object sender, EventArgs e)
        {
            if (true)
            {
                textChanged = 1;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void mnuViewFont_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = fontDialog1.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            Font font = fontDialog1.Font;
            tbMemo.Font = font;

            setFontInfo();
        }

        private void mnuFilePrint_Click(object sender, EventArgs e)
        {

        }

        private void setFontInfo()
        {
            string defaultFont = tbMemo.Font.Name;
            // Font.size의 자료형이 float인 이유는 실제 크기를 의미하기 때문입니다.
            float defaultSize = tbMemo.Font.Size;
            // int 자료형의 데이터를 활용하기 위해 Height를 사용합니다.(????)
            // int defaultSize = tbMemo.Font.Height;
            statusForm1Font.Text = "font : " + defaultFont;
            statusForm1Size.Text = "size : " + defaultSize;
        }

    }
}
