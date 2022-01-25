using System;

namespace RoundRobin
{
    public class RoundRobin
    {

		// Calcul temps d'attente des processus
		public void WaitingTime(int[] processes, int n, int[] burstTime, int[] waitingTime, int quantum)
		{
			// on met à jour le temps restant d'éxecution
			int[] remainingBurstTime = new int[n];
			for (int i = 0; i < n; i++)
			{
				remainingBurstTime[i] = burstTime[i];
			}

			int t = 0 , tmp; // temps actuel et variable temporaire
			bool boucle = true;

			// on boucle tant qu'il y a des processus
			while (boucle)
			{
				// on parcours tous les processus
				for (int i = 0; i < n; i++)
				{
					tmp = remainingBurstTime[i];
					//si pas fini
					if (tmp > 0)
					{
						if (tmp > quantum) 
						{
							t += quantum; // on augmente de quantum
							remainingBurstTime[i] -= quantum;

						}
						else
						{
							remainingBurstTime[i] = 0;
							t = t + tmp; // on met à jour le temps avec le temps d'éxecution restant
							waitingTime[i] = t - burstTime[i];
						}
						boucle = true;

					}
                    else
                    {
						boucle = false;
					}
				}
			}
		}

		public void AverageTime(int[] processes, int n, int[] burstTime, int quantum)
		{
			int tmp, totalWaiting = 0, totalTurnAround = 0;
			int[] turnAroundTime = new int[n]; // temps avant fin d'éxecution
			int[] waitingTime = new int[n];

			WaitingTime(processes, n, burstTime, waitingTime, quantum);

			Console.WriteLine("Proc\tBurst\tWait\tTurn around");

			// on calcul le turnaround time et le temps cumulé d'attente
			for (int i = 0 ; i < n ; i++)
			{
				tmp = waitingTime[i]; // on récupère le temps d'attente

				turnAroundTime[i] = burstTime[i] + tmp;
				totalWaiting = totalWaiting + tmp; //calcul temps cumulé d'attente
				totalTurnAround = totalTurnAround + turnAroundTime[i]; 

				Console.WriteLine(" " + (i + 1) + "\t " + burstTime[i] + "\t " + tmp + "\t " + turnAroundTime[i]);
			}

			Console.WriteLine("Average waiting time = " + (float)totalWaiting / (float)n);
			Console.WriteLine("Average turn around time = " + (float)totalTurnAround / (float)n);
		}

		public static void Main()
		{
			RoundRobin R = new RoundRobin();

			int[] processes = { 1, 2, 3 }; // numéro processus
			int[] burstTime = { 4, 3, 2 }; //temps d'éxecution
			int n = 3;

			int quantum = 2; //temps avant changement
			R.AverageTime(processes, n, burstTime, quantum);
		}
	}
}

