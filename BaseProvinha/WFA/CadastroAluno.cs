using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class CadastroAluno : Form
    {
        private Aluno aluno;
        private int codigo;
        public CadastroAluno()
        {
            InitializeComponent();
        }

        public CadastroAluno(int codigo)
        {
            this.codigo = codigo;
            for(int i = 0; i < Program.alunos.Count(); i++)
            {
                Aluno aluno = Program.alunos[i];
                if (aluno.GetCodigo() == codigo)
                {
                    txtNome.Text = aluno.GetNome();
                    txtIdade.Text = Convert.ToString(aluno.GetIdade());
                    txtMatricula.Text = Convert.ToString(aluno.GetMatricula());
                    txtTurma.Text = aluno.GetTurma();
                    txtTurno.Text = aluno.GetTurno();
                    this.aluno = aluno;
                    btnAdicionar.Enabled = true;
                    btnApagar.Enabled = true;
                    btnEditar.Enabled = true;
                    return;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bool novo = aluno == null;
                    if (aluno != null)
                    {
                        aluno = new Aluno();
                    }

                aluno = new Aluno();
                aluno.SetNome(txtNome.Text);
                aluno.SetIdade(Convert.ToInt32(txtIdade.Text));
                aluno.SetTurma(txtTurma.Text);
                aluno.SetTurno(txtTurno.Text);
                aluno.SetMatricula(Convert.ToInt32(txtMatricula.Text));
                if (novo)
                {
                    Program.alunos.Add(aluno);
                    

                }
                else
                {
                    for (int i = 0;  i < Program.alunos.Count(); i++)
                    {
                        Aluno alunoAux = Program.alunos[i];
                        if(aluno.GetCodigo() == alunoAux.GetCodigo())
                        {
                            Program.alunos[i] = aluno;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new CadastroAlunoNota(aluno).ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                AtualizarDataGridViewDasNotas();
                MessageBox.Show("Cadastro realizado com sucesso !!");
            }
        }

        private void AtualizarDataGridViewDasNotas(){
            dataGridView1.Rows.Clear();
            for (int i = 0; i < aluno.GetNotas().Count(); i++)
            {
                double nota = aluno.GetNotas()[i];
                dataGridView1.Rows.Add(new Object[] { nota });
            }
        }
    }
}
