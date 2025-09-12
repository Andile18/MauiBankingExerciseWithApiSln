﻿using MauiBankingExercise.Views;

namespace MauiBankingExercise
{
    public partial class AppShell : Shell
    {
       
            public AppShell()
            {
                InitializeComponent();

                Routing.RegisterRoute("customerview", typeof(ClientView));
                Routing.RegisterRoute("transactionsview", typeof(TransactionView));

        }
        }
    }
