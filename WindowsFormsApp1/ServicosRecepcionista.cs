﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ServicosRecepcionista : Form
    {
        public ServicosRecepcionista()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ServicosRecepcionista_Load(object sender, EventArgs e)
        {
            textLogincliente.Enabled = (checkboxCheckin.Checked || checkboxCancelar.Checked || checkboxCheckout.Checked);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkboxReserva_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxReserva.Checked)
            {
                checkboxCancelar.Checked = false;
                checkboxCheckin.Checked = false;
                checkboxCheckout.Checked = false;
            }
            textNome.Enabled = checkboxReserva.Checked;
            textLogin.Enabled = checkboxReserva.Checked;
            textSenha.Enabled = checkboxReserva.Checked;
            textCPF.Enabled = checkboxReserva.Checked;
            textEntrada.Enabled = checkboxReserva.Checked;
            textSaida.Enabled = checkboxReserva.Checked;
            textPessoas.Enabled = checkboxReserva.Checked;
        }

        private void checkboxCancelar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxCancelar.Checked)
            {
                checkboxReserva.Checked = false;
                checkboxCheckin.Checked = false;
                checkboxCheckout.Checked = false;
            }
            textLogincliente.Enabled = (checkboxCheckin.Checked || checkboxCancelar.Checked || checkboxCheckout.Checked);
        }
        private void checkboxCheckin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxCheckin.Checked)
            {
                checkboxCancelar.Checked = false;
                checkboxReserva.Checked = false;
                checkboxCheckout.Checked = false;
            }
            textLogincliente.Enabled = (checkboxCheckin.Checked || checkboxCancelar.Checked || checkboxCheckout.Checked);
        }
        private void checkboxCheckout_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxCheckout.Checked)
            {
                checkboxCancelar.Checked = false;
                checkboxCheckin.Checked = false;
                checkboxReserva.Checked = false;
            }
            textLogincliente.Enabled = (checkboxCheckin.Checked || checkboxCancelar.Checked || checkboxCheckout.Checked);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkboxReserva.Checked)
                {
                    //Hospede h1 = new Hospede(textNome.Text, textCPF.Text, textAno.Text, textEmail.Text, Convert.ToInt32(textAno.Text))

                    Random rnd = new Random();
                    int id_reserva = rnd.Next(0, 2147483647);
                    //int id_reserva = 12345;
                    BancoDados.criaReserva(id_reserva.ToString() , textEntrada.Text, textSaida.Text, Convert.ToInt32(textPessoas.Text));

                    BancoDados.criaHospede(id_reserva.ToString(), textNome.Text, textCPF.Text, textLogin.Text ,  textSenha.Text);

                    MessageBox.Show("Reserva realizada!", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Existem campos incompletos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string mensagem;
                if (checkboxCheckin.Checked)
                {
                    string quarto = BancoDados.checkIn(textLogincliente.Text);
                    if (quarto == "vazio")
                    {
                        mensagem = "O hospede de CPF " + textCPF + " Fez checkin no quarto " + quarto;
                    }

                }
                if (checkboxCheckout.Checked)
                {
                    BancoDados.deletaReserva(textLogincliente.Text);
                    mensagem = "O hospede de CPF " + textCPF + "Fez checkout";
                }
                if (checkboxCancelar.Checked)
                {
                    BancoDados.deletaReserva(textLogincliente.Text);
                    mensagem = "O hospede de CPF " + textCPF + "Cancelou sua reserva";
                }
                else
                {
                    BancoDados.deletaReserva(textLogincliente.Text);
                    mensagem = "Clique em uma das opções";
                }
                textLogincliente.Enabled = (checkboxCheckin.Checked || checkboxCancelar.Checked || checkboxCheckout.Checked);
                
                MessageBox.Show("lol", mensagem , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao deletar o hospede", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
