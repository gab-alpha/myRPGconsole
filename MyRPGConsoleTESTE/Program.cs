using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace MyRPGConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Herói", 100, 10, 0);

            List<Enemy> enemies = new List<Enemy>
            {
                new Goblin(),
                new Orc(),
                new Dragon(),
                new Skeleton(),
                new Zombie(),
                new Mage()
            };
            #region LISTA DE EVENTOS
            List<Event> events = new List<Event>
            {
                new EncounterEvent("> Você encontrou um >Goblin< !", new Goblin()),
                new EncounterEvent("> Um >Orc< apareceu!", new Orc()),
                new QuestEvent("> Você encontrou um aldeão necessitando de ajuda.", "Ajude o aldeão a recuperar seu tesouro.", new Weapon("Espada de Ouro", "Uma espada brilhante e valiosa.", 20)),

                new EnvironmentalEvent("> Você avista cultistas enaltecendo a praga (É sério?)","cultistas"),
                new EnvironmentalEvent("> Um bardo faz um poema pra você. Na verdade não era um poema e sim " +
                                       "um insulto, ele está tirando sarro de você","bardo desafinado"),
                new EnvironmentalEvent("> Você encontra uma carroça destruída, parece que era de um mercador", "carroça destruida"),
                new EnvironmentalEvent("> Chegou de noite... e parece que dessa vez a lua é cheia","Lua cheia"),
                new EnvironmentalEvent("> Esse clima úmido te deixa com um resfriado. Você pode até ser for" +
                                       "te, mas a gripe é mais","gripe"),
                new EnvironmentalEvent("> Você avista uma pessoa tossindo sangue e agonizando, algumas p" +
                                       "essoas ao redor dizem que aquilo é a praga...","vitima praga"),
                new EnvironmentalEvent("> Uma enorme paz de espírito te atinge...é como se algo não " +
                                       "quisesse mais guerra","paz de espirito"),
                new EnvironmentalEvent("> O Campeão é um indivíduo que tem a procura constante por desafios," +
                                       " será que você é um desafio pra ele?","o campeão"),
                new EnvironmentalEvent("> Você percebe pessoas falando sobre uma praga, aparentemente sem cura." +
                                       " Dizem que é mágica e de razões divinas","murmuros praga"),
                new EnvironmentalEvent("> Uma multidão por perto está discutindo sobre a praga," +
                                       " algo muito misterioso","praga?"),
                new EnvironmentalEvent("> Os pássaros cantam como nunca, não tem nada de errado por aqui...","canto dos passaros"),
                new EnvironmentalEvent("> Muitos falam da praga, mas será que ela é algo que realmente existe?","praga real?"),
                new EnvironmentalEvent("> Alguns entulhos cobrem sua passagem, você decide tomar outro caminho","obstaculos no caminho"),
                new EnvironmentalEvent("> O céu escureceu e começou a chover.", "chuva"),
                new EnvironmentalEvent("> Uma tempestade está se formando no horizonte.", "tempestade"),
                new EnvironmentalEvent("> Passeando pelos campos você encontra uma cachoeira e um riacho, você prefere passar " +
                                       "um tempo ali para aproveitar e calmaria e a vida amena",
                                       "cachoeira"),
                new EnvironmentalEvent("> Pegadas enormes, destruição e desespero...o que passou por aqui?", "rastros de destruição"),
                new EnvironmentalEvent("> Você resolve trocar informações com os outros das redondezas","trocar informações"),
                new TrapEvent("> Você ativou uma armadilha enquanto passava desatento", 20),
                new TrapEvent("> Você estava explorando as colinas e acabou tropeçando", 5),
                new EnvironmentalEvent("> Você é parado por um dos cavalheiros reais e é convidado a um >BANQUETE REAL<." +
                                       " O reino agradece por todas as suas boas vontades", "banquete"),
                //new NpcEvent("Você encontrou um mercador viajante.", "Mercador", "Eu tenho itens raros para trocar, você está interessado?", new MagicRing("Anel de Poder", "Aumenta o poder mágico.", 15)),
                new TreasureEvent("> Você encontrou um baú escondido!", new HealingPotion("Grande Poção de Cura", "Recupera 50 de saúde.", 50)),
                new ChallengeEvent("> Você encontrou um portão com um enigma gravado.", "> Qual é o número que, se multiplicado por si mesmo, dá 25?", "5", new Weapon("Espada Mística", "Uma espada com poder místico.", 30))
            };
            #endregion
            Random random = new Random();

            #region GUI DE LOGIN

            Console.WriteLine("_________________________________________________._____________________________________________]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                            -->| Bem-vindo ao RPG de Console! |<--                             ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("__________________________________________________.____________________________________________]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine(@"                                      |\                     /)                                ]");
            Console.WriteLine(@"                                    /\_\\__               (_//                                 ]");
            Console.WriteLine(@"                                   |   `>\-`     _._       //`)                                ]");
            Console.WriteLine(@"                                    \ /` \\  _.-`:::`-._  //                                   ]");
            Console.WriteLine(@"                                     `    \|`    :::    `|/                                    ]");
            Console.WriteLine(@"         Aguarde enquanto                  |     :::     |                                     ]");
            Console.WriteLine(@"           o jogo está                     |.....:::.....|                                     ]");
            Console.WriteLine(@"           está sendo                      |:::::::::::::|                                     ]");
            Console.WriteLine(@"            iniciado                       |     :::     |                                     ]");
            Console.WriteLine(@"                                           \     :::     /                                     ]");
            Console.WriteLine(@"                                            \    :::    /                                      ]");
            Console.WriteLine(@"                                             `-. ::: .-'                                       ]");
            Console.WriteLine(@"                                              //`:::`\\                                        ]");
            Console.WriteLine(@"                                             //   '   \\                                       ]");
            Console.WriteLine(@"                                            |/         \\                                      ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                       L O A D I N G . . .     ]");
            Console.WriteLine("________________________________________________.______________________________________________]");
            #endregion
            Thread.Sleep(10000);  //10s para o Usuário se acostumar com a possível interface e preparar para o próximo menu
            Console.Clear();
            #region GUI DE ESTABILIDADE

            Console.WriteLine("[________________________________________.______________________________________________]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                 -->| GUIA DE ESTABILIDADE E FUNCIONAMENTO |<--                        ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[________________________________________.______________________________________________]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                                  A T E N Ç Ã O                                        ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[              O programa é executado em uma tela de prompt, é ideal                    ]xxxxxx");
            Console.WriteLine("[                          que seja feita algumas muandaças.                            ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[               Não clicar na tela e respeitar a margem é obrigatório                   ]xxxxxx");
            Console.WriteLine("[                  para o bom funcionamento da tarefa e execução.                       ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                É necessário redimensionar a tela visando que os X fiquem              ]xxxxxx");
            Console.WriteLine("[                       quase no limite da margem do prompt.                            ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                 As ações são efetivadas baseado no que é digitado e                   ]xxxxxx");
            Console.WriteLine("[                  enviado, maioria das mesmas são identificadas pelo                   ]xxxxxx");
            Console.WriteLine("[                  primeiro caractere e selecionado entre parênteses.                   ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[    > Assim que você estiver conscientizado, digite qualquer caractere para começar    ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[                                                                                       ]xxxxxx");
            Console.WriteLine("[________________________________________.______________________________________________]xxxxxx");
            Console.ReadKey();
            Console.Clear();
            #endregion



            #region GUI DE LOADING
            Console.WriteLine("_________________________________________________._____________________________________________]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                            -->| Bem-vindo ao RPG de Console! |<--                             ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("__________________________________________________.____________________________________________]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine(@"                                      |\                     /)                                ]");
            Console.WriteLine(@"                                    /\_\\__               (_//                                 ]");
            Console.WriteLine(@"                                   |   `>\-`     _._       //`)                                ]");
            Console.WriteLine(@"                                    \ /` \\  _.-`:::`-._  //                                   ]");
            Console.WriteLine(@"                                     `    \|`    :::    `|/                                    ]");
            Console.WriteLine(@"         Aguarde enquanto                  |     :::     |                                     ]");
            Console.WriteLine(@"           o jogo está                     |.....:::.....|                                     ]");
            Console.WriteLine(@"           está sendo                      |:::::::::::::|                                     ]");
            Console.WriteLine(@"            iniciado                       |     :::     |                                     ]");
            Console.WriteLine(@"                                           \     :::     /                                     ]");
            Console.WriteLine(@"                                            \    :::    /                                      ]");
            Console.WriteLine(@"                                             `-. ::: .-'                                       ]");
            Console.WriteLine(@"                                              //`:::`\\                                        ]");
            Console.WriteLine(@"                                             //   '   \\                                       ]");
            Console.WriteLine(@"                                            |/         \\                                      ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                                               ]");
            Console.WriteLine("                                                                       L O A D I N G . . .     ]");
            Console.WriteLine("________________________________________________.______________________________________________]");
            #endregion

            while (player.Health > 0)
            {
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine($"| HERÓI || RUNS {player.qntRuns} || HP >{player.Health}< || DANO >{player.AttackPower}< |");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("Escolha uma ação -> (E)xplorar | (I)nventário");
                Console.WriteLine("==================================================================================");
                string action = Console.ReadLine().ToLower();
                Console.WriteLine("");

                if (action == "e")
                    
                #region LÓGICA DE EXPLORAÇÃO(E)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("                  EXPLORANDO   (...)");
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Thread.Sleep(4000);
                    Console.Clear();
                    Event currentEvent = events[random.Next(events.Count)];
                    currentEvent.Trigger(player);
                    player.qntRuns++;
                    #endregion
                    if (currentEvent is EncounterEvent encounterEvent)
                    {
                        Enemy currentEnemy = encounterEvent.Enemy;
                        Console.WriteLine($"Você encontrou um {currentEnemy.Name}!");
                        Console.WriteLine("");
                        Console.WriteLine("--------------------------------------------------------------------");

                        while (player.Health > 0 && currentEnemy.Health > 0)
                        {
                            #region GUI COMBATE
                            Console.Clear();
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine($"        | HERÓI || RUNS {player.qntRuns} || HP >{player.Health}< || DANO >{player.AttackPower}< |");
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("                     |...     VS      ...|");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine($"        | {currentEnemy.Name} || DROP xxx || HP >{currentEnemy.Health}< || DANO >{currentEnemy.AttackPower}< |");
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("Escolha uma ação -> (A)tacar | (F)ugir | (I)nventário | (C)onversar");
                            Console.WriteLine("-------------------------------------------------------------------");

                            #endregion

                            string combatAction = Console.ReadLine().ToLower();

                            if (combatAction == "a")
                            #region LÓGICA DE ATACAR(A)
                            {
                                player.Attack(currentEnemy);
                                if (currentEnemy.Health > 0)
                                {
                                    currentEnemy.Attack(player);
                                }
                                #endregion
                            }
                            else if (combatAction == "f")
                            {
                                Console.WriteLine("Você fugiu da batalha!");
                                break;
                            }
                            else if (combatAction == "i")
                            {
                                player.ShowInventory();
                                Console.WriteLine("Digite o nome do item para usar ou pressione Enter para voltar:");
                                string itemName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(itemName))
                                {
                                    player.UseItem(itemName);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ação inválida. Tente novamente.");
                            }
                        }

                        if (player.Health <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("                           ............");
                            Console.WriteLine("                Você foi derrotado!");
                            Console.WriteLine("                           ............");
                            Console.WriteLine("");
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine($" A sua aventura durou mais de {player.qntRuns} ! ");
                            break;
                        }
                        else if (currentEnemy.Health <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Você derrotou o {currentEnemy.Name}!");
                            foreach (var lootItem in currentEnemy.LootTable)
                            {
                                if (random.NextDouble() <= lootItem.DropChance)
                                {
                                    player.AddItem(lootItem.Item);
                                }
                            }
                        }
                    }
                }
                else if (action == "i")
                {
                    player.ShowInventory();
                    Console.WriteLine("Digite o nome do item para usar ou pressione Enter para voltar:");
                    Console.WriteLine();
                    string itemName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(itemName))
                    {
                        player.UseItem(itemName);
                    }
                }
                else
                {
                    Console.WriteLine("Ação inválida. Tente novamente.");
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("Você foi derrotado!");
            }
        }
    }
}


