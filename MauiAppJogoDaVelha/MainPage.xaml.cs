using System;
using System.Collections.Generic;
using System.Linq;

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Jogador (X)
            btn.Text = "X";
            btn.IsEnabled = false;

            if (VerificarVitoria("X"))
            {
                await DisplayAlertAsync("Parabéns", "Você ganhou! 🎉", "OK");
                Zerar();
                return;
            }

            if (DeuVelha())
            {
                await DisplayAlertAsync("Empate", "Deu velha!", "OK");
                Zerar();
                return;
            }

            // Máquina joga
            JogadaMaquina();
        }

        bool VerificarVitoria(string jogador)
        {
            return
                // Linhas
                (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) ||
                (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) ||
                (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) ||

                // Colunas
                (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) ||
                (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) ||
                (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) ||

                // Diagonais
                (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) ||
                (btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador);
        }

        bool DeuVelha()
        {
            return
                btn10.Text != "" && btn11.Text != "" && btn12.Text != "" &&
                btn20.Text != "" && btn21.Text != "" && btn22.Text != "" &&
                btn30.Text != "" && btn31.Text != "" && btn32.Text != "";
        }

        async void JogadaMaquina()
        {
            List<Button> botoes = new List<Button>
            {
                btn10, btn11, btn12,
                btn20, btn21, btn22,
                btn30, btn31, btn32
            };

            var livres = botoes.Where(b => b.Text == "").ToList();

            if (livres.Count == 0) return;

            Random rnd = new Random();
            Button escolha = livres[rnd.Next(livres.Count)];

            escolha.Text = "O";
            escolha.IsEnabled = false;

            if (VerificarVitoria("O"))
            {
                await DisplayAlertAsync("Fim de jogo", "A máquina ganhou 😈", "OK");
                Zerar();
                return;
            }

            if (DeuVelha())
            {
                await DisplayAlertAsync("Empate", "Deu velha!", "OK");
                Zerar();
            }
        }

        void Zerar()
        {
            List<Button> botoes = new List<Button>
            {
                btn10, btn11, btn12,
                btn20, btn21, btn22,
                btn30, btn31, btn32
            };

            foreach (var btn in botoes)
            {
                btn.Text = "";
                btn.IsEnabled = true;
            }
        }
    }
}