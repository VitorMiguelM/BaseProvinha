using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Aluno
    {
        private int Codigo;
        private string Nome;
        private int Idade;
        private string Turno;
        private string Turma;
        private int Matricula;
        private List<double> Notas = new List<double>();

        public void SetNome(string nome)
        {
            if (nome.Trim().Count() < 3)
            {
                throw new Exception("Nome deve conter no mínimo 3 caracteres");
            }
            if (nome.Trim().Count() > 100)
            {
                throw new Exception("Nome deve conter no máximo 100 caracteres");
            }
            Nome = nome;
        }
        
        public string GetNome()
        {
            return Nome;
        }

        public void SetIdade(int idade)
        {
            if (idade < 4)
            {
                throw new Exception("Idade deve ser no mínimo maior que 4");
            }
            if (idade > 23)
            {
                throw new Exception("Idade deve ser menor que 23");
            }
            Idade = idade;
        }

        public int GetIdade()
        {
            return Idade;
        }

        public void SetTurno(string turno)
        {
            if (turno.Trim().Count()  < 7)
            {
                throw new Exception("Turno deve conter no mínimo 7 caracteres");
            }
            if (turno.Trim().ToLower() != "matutino" &&
                turno.Trim().ToLower() != "vespertino" &&
                turno.Trim().ToLower() != "noturno")
            {
                throw new Exception("Turno deve conter somente Matutino ou Vespertino ou Noturno");
            }
            Turno = turno;
        }

        public string GetTurno() { return Turno; }

        public void SetTurma(string turma)
        {
            if (turma.Trim().Count() < 1)
            {
                throw new Exception("Turno deve conter no mínimo 1 caracter");
            }
            if (turma.Trim().Count() > 3)
            {
                throw new Exception("Turno deve conter no máximo 3 caracter");
            }    
            Turma = turma;
        }
        public string GetTurma() { return Turma; }

        public void SetMatricula(int matricula)
        {
            if (matricula < 0) { 
                throw new Exception("Matrícula tem que ser maior que 0"); 
            }
            Matricula = matricula;
        }


        public void AdicionarNota(double nota)
        {
            Notas.Add(nota);
        }

        public List<double> GetNotas()
        {
            return Notas;
        }
    }
}
