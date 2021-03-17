// 회색으로 기입되어있는 클래스는 default로 기입되었으나 하단 코드에서 사용하고 있지 않음을 의미합니다.
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

/* 코드의 생성 및 수정은 디자인창의 속성에서 변경하는 것이 권장됩니다. */
namespace WinFormsApp1
{    // partial : 나눠져있는 클래스임을 명시하는 키워드 입니다.
    public partial class Form1 : Form
    {
        bool status = false;    // int status = 0;
        public Form1()
        {
            // Form1 클래스가 생성될때 초기화를 담당하는 메서드 입니다.
            // Form1.Designer.cs 에 메서드의 바디가 명시되어있어 클래스 명 없이 메서드 명으로만 호출할 수 있습니다.
            InitializeComponent();
        }

        // button1을 클릭하는 이벤트가 발생했을 때의 작업을 정의하는 메서드입니다.
        // Form1.cs[Design]에서 버튼을 만들고 속성 창에서 이벤트탭으로 이동 합니다. 목록의 'click'을 더블클릭하면 자동으로 생성됩니다.
       /* 
            private void button1_Click(object sender, EventArgs e)
            {
                if(status == true) {
                    btnTest.Text = "Button Test 1";
                } else {
                    btnTest.Text = "Button Test 2";
                }
                // C# 에서는 '!' 연산자를 int 자료형에 사용할 수 없습니다.
                // 16 line의 'int status = 0;'을 'bool status = false;' 또는 'bool status = true'로 변경해야 합니다.
                status = !status;
            }
       */

        // 이벤트 작업 메서드의 이름을 변경하기 위해서 디자인창의 속성창에서 이벤트 이름을 변경할 경우 새로운 메서드가 생성됩니다.
        // 기존의 작업 코드를 복사해서 새로운 메서드의 중괄호 블록에 붙여넣기 합니다.
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                btnTest.Text = "Button Test 1";
            }
            else
            {
                btnTest.Text = "Button Test 2";
            }
            // C# 에서는 '!' 연산자를 int 자료형에 사용할 수 없습니다.
            // 16 line의 'int status = 0;'을 'bool status = false;' 또는 'bool status = true'로 변경해야 합니다.
            status = !status;
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult ret = openFileDialog1.ShowDialog();
            if(ret == DialogResult.Cancel) {    // 파일이 선택되지 않으면 리턴합니다.
                return;
            }

            string fileName = openFileDialog1.FileName; // openFileDialog.FileName : 파일의 전체 경로를 리턴합니다.
            StreamReader streamReader = new StreamReader(fileName);
            string buf = streamReader.ReadToEnd();       // ReadToEnd() 메소드는 파일 내용을 처음부터 끝까지 읽어 리턴합니다.
            streamReader.Close();
            textBoxMemo.Text = buf;
            //streamReader.Read();
        }
                
        private void btnFileSave_Click(object sender, EventArgs e)
        {

            DialogResult ret = saveFileDialog1.ShowDialog();
            if (ret == DialogResult.Cancel)
            {    // 파일이 선택되지 않으면 리턴합니다.
                return;
            }
            string fileName = saveFileDialog1.FileName; // saveFileDialog.FileName : dialog에서 선택한 위치의 전체 경로를 리턴합니다.

            StreamWriter streamWriter = new StreamWriter(fileName); // save이므로 writer
            string buf = textBoxMemo.Text;    // 굳이 필요없는 단계임
            streamWriter.Write(buf);          // streamWriter.Write(textBoxMemo.Text);
            streamWriter.Close();
        }

        private void btnModifyStr_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;                // C++ CString
            string upper = input.ToUpper();                  // CString str;
            outputTestBox.Text = upper;                      // str.Format("%d", n);
            //etcTextBox.Text = input.Length.ToString();     // SetWindowText(str);
            // $ " {..., 자리수:변환자(C,D,E,F,G,X)} " = 보간 문자열,  중괄호{} 가 복수로 들어가도 사용가능합니다.
            // 2번째 매개변수 자리는 해당 문자열을 출력하기위해 확보할 공간의 크기를 의미합니다.
            // : 이후 매개변수 자리는 변환자가 위치합니다. ex) X = 16진수
            etcTextBox.Text = $"변환된 문자열은\"{upper}\"이며, 문자열의 길이는 {input.Length, 5:X}입니다.";       
        }

        private void btnCallForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if(form2.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = form2.comboBoxTexts[0] + "\r\n" +
                                form2.comboBoxTexts[1] + "\r\n" +
                                form2.comboBoxTexts[2];
            }
        }
    }
}
