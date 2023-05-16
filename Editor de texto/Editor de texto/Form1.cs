using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_de_texto
{
    public partial class f_EditorTexto : Form
    {
        StringReader leitura = null;

        public f_EditorTexto()
        {
            InitializeComponent();
        }
        //Apaga todo texto digitado
        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        //Cria um arquivo e salva o que foi digitado
        private void Salvar()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter streamWriter = new StreamWriter(arquivo);
                    streamWriter.Flush();
                    streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    streamWriter.Write(this.richTextBox1.Text);
                    streamWriter.Flush();
                    streamWriter.Close();

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro na gravação: " + ex.Message, "Erro ao gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Abre um arquivo existente
        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            string usuarioLogado = System.Environment.UserName;
            openFileDialog1.InitialDirectory = @"C://Users//" +usuarioLogado+ "//Documents";
            openFileDialog1.Filter = "(*.txt)|*.txt|Todos Arquivos(*.*)|*.*";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(arquivo);
                    streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = streamReader.ReadLine();
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = streamReader.ReadLine();
                    }
                    streamReader.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro de leitura: " + ex.Message, "Erro ao ler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Copiar texto selecionado
        private void Copiar()
        {
            if(richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        //Colar texto copiado
        private void Colar()
        {
            richTextBox1.Paste();
        }

        //Tranforma texto em negrito
        private void Negrito()
        {
            string nome_da_fonte = fontDialog1.Font.Name;
            float tamanho_da_fonte = fontDialog1.Font.Size;
            bool negrito, italico,sublinhado = false;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            if (negrito == false)
            {
                if(sublinhado == true && italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (sublinhado == false && italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (sublinhado == true && italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (sublinhado == false && italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
            }
            else
            {
                if (sublinhado == true && italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (sublinhado == false && italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
                else if (sublinhado == true && italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
                else if (sublinhado == false && italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
                }
            }
        }

        //Transforma texto em italico
        private void Italico()
        {
            string nome_da_fonte = fontDialog1.Font.Name;
            float tamanho_da_fonte = fontDialog1.Font.Size;
            bool negrito, italico, sublinhado = false;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            if (italico == false)
            {
                if (sublinhado == true && negrito == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (sublinhado == false && negrito == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (sublinhado == true && negrito == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (sublinhado == false && negrito == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
            }
            else
            {
                if (sublinhado == true && negrito == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (sublinhado == false && negrito == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
                else if (sublinhado == true && negrito == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
                else if (sublinhado == false && negrito == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
                }
            }
        }

        //Transforma texto em sublinhado
        private void Sublinhado()
        {
            string nome_da_fonte = fontDialog1.Font.Name;
            float tamanho_da_fonte = fontDialog1.Font.Size;
            bool negrito, italico, sublinhado = false;
            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            if (sublinhado == false)
            {
                if (italico == true && negrito == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (italico == false && negrito == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (italico == true && negrito == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (italico == false && negrito == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
            }
            else
            {
                if (italico == true && negrito == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (italico == false && negrito == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
                else if (italico == true && negrito == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
                else if (italico == false && negrito == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
                }
            }
        }

        private void fonte()
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = new Font(fontDialog1.Font.Name, fontDialog1.Font.Size);
            }
        }

        // Funçoes de Alinhamento Esquerda, Direita e Centro
        private void alinharEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void alinharCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void imprimir()
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Se houver algum texto digitado antes de criar novo arquivo pergunta usuário se deseja salvar
            if (this.richTextBox1.TextLength != 0)
            {
                var resultado = MessageBox.Show("Deseja Salvar o arquivo de texto?", "Salvar",
                                     MessageBoxButtons.YesNoCancel,
                                     MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Salvar();
                    Novo();
                }
                else if (resultado == DialogResult.No)
                {
                    Novo();
                }
            }
        }
        private void btn_novo_Click(object sender, EventArgs e)
        {
            //Se houver algum texto digitado antes de criar novo arquivo pergunta usuário se deseja salvar
            if (this.richTextBox1 != null)
            {
                var resultado = MessageBox.Show("Deseja Salvar o arquivo de texto?", "Salvar",
                                     MessageBoxButtons.YesNoCancel,
                                     MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Salvar();
                    Novo();
                }
                else if (resultado == DialogResult.No)
                {
                    Novo();
                }
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void btn_centralizar_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        //Configura o documento da pagina para impressão
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float posY = 0;
            int cont = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Top - 50;
            if(margemEsquerda < 5)
            {
                margemEsquerda = 20;
            }
            if (margemSuperior < 5)
            {
                margemSuperior = 20;
            }
            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
            linha = leitura.ReadLine();
            while(cont < linhasPagina)
            {
                posY = margemSuperior + (cont * fonte.GetHeight(e.Graphics));
                e.Graphics.DrawString(linha, fonte, pincel, margemEsquerda, posY, new StringFormat());
                cont++;
                linha = leitura.ReadLine();
            }
            if(linha != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();
        }

        private void btn_fonte_Click(object sender, EventArgs e)
        {
            fonte();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fonte();
        }
        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Desfazer ultimo texto digitado
            richTextBox1.Undo();
        }
        private void refazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Refazer texto anterior 
            richTextBox1.Redo();
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void f_EditorTexto_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Se houver algum texto digitado antes fechar programa pergunta usuário se deseja salvar
            if (this.richTextBox1.TextLength != 0)
            {  
                var resultado = MessageBox.Show("Deseja Salvar o arquivo de texto?", "Salvar",
                                     MessageBoxButtons.YesNoCancel,
                                     MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Salvar();
                }
                else if (resultado == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
