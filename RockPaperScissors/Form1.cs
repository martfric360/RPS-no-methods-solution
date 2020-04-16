﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, opposite, cpuChoice;
        int wins = 0;
        int losses = 0;
        int ties = 0;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        Graphics g;

        public Form1()
        {
            InitializeComponent();

            g = this.CreateGraphics();
        }
        
        public void ComputerTurn()
        {
            //determine and set cpu choice. display cpu image
            int randValue = randGen.Next(1, 4);

            if (randValue == 1)
            {
                cpuChoice = "rock";
                g.DrawImage(rockImage, 360, 70, 168, 280);
            }
            else if (randValue == 2)
            {
                cpuChoice = "paper";
                g.DrawImage(paperImage, 360, 70, 168, 280);
            }
            else
            {
                cpuChoice = "scissors";
                g.DrawImage(scissorImage, 360, 70, 168, 280);
            }
        }

        public void DetermineWinner()
        {
            if (playerChoice == cpuChoice)
            {
                g.DrawImage(tieImage, 225, 5, 250, 150);
                ties++;
                tiesLabel.Text = "Ties: " + ties;
            }
            else if (cpuChoice == opposite)
            {
                g.DrawImage(loseImage, 225, 5, 250, 150);
                losses++;
                lossesLabel.Text = "Losses: " + losses;
            }
            else
            {
                g.DrawImage(winImage, 225, 5, 250, 150);
                wins++;
                winsLabel.Text = "Wins: " + wins;
            }

        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            //set player choice
            playerChoice = "rock";
            opposite = "paper";
            ComputerTurn();

            //play sound and display player choice image
            jabPlayer.Play();
            g.DrawImage(rockImage, 168, 70, 168, 280);
            Thread.Sleep(1000);

            //determine who the winner is and display result
            DetermineWinner();

            gongPlayer.Play();
            Thread.Sleep(3000);
            Refresh();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            //set player choice
            playerChoice = "paper";
            opposite = "scissors";
            ComputerTurn();

            //play sound and display player choice image
            g.DrawImage(paperImage, 168, 70, 168, 280);
            jabPlayer.Play();
            Thread.Sleep(1000);

            //determine who the winner is and display result
            DetermineWinner();

            gongPlayer.Play();
            Thread.Sleep(3000);
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            //set player choice
            playerChoice = "scissors";
            opposite = "rock";
            ComputerTurn();
           

            //play sound and display player choice image
            jabPlayer.Play();
            g.DrawImage(scissorImage, 168, 70, 168, 280);
            Thread.Sleep(1000);

            //determine who the winner is and display result
            DetermineWinner();

            gongPlayer.Play();
            Thread.Sleep(3000);
            Refresh();
        }



    }


}
