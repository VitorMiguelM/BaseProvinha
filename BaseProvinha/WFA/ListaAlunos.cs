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
    public partial class ListaAlunos : Form
    {
        public ListaAlunos()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new CadastroAluno().ShowDialog();
        }

        private void ListaAlunos_Activated(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Program.alunos.Count(); i++)
            {
                Aluno aluno = Program.alunos[i];
                dataGridView1.Rows.Add(new Object[] { 
                    aluno.GetNome(),
                    aluno.GetTurma(),
                    aluno.GetTurno(),
                    aluno.GetIdade()
                });
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CadastroAluno cadastroAluno = new CadastroAluno();
            new CadastroAluno().ShowDialog();
            
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Não tem nenhum aluno selecionada!");
                return;
            }

            posicao = dataGridView1.CurrentRow.Index;
            Aluno alunos = Program.alunos[posicao];
            InserirInformacoesDoAlunoNoCadastro();

            
        }
    }
}
