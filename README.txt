[Pokémon Memory]
Corso di Advanced Programming Languages - A.A. 2021/2022
Studente: Nuñez Pereira Mario Roberto (1000012381)

Al fine di avviare correttamente l'applicativo e necessario seguire i seguenti passaggi:

[DATABASE]
- È possibile importare un database preconfigurato denominato "pokemonmemoryrank.sql",
  presente nella cartella "..\PokémonMemory", con all'interno alcuni utenti ed i relativi
  punteggi. 

- In alternativa, il database verrà automaticamente creato (vuoto) dal Server
  dell'applicativo una volta configurato ed eseguito correttamente.
  (Si consiglia l'utilizzo del software "MySQL Workbench 8.0 CE" o successivi)

[SERVER]
"ATTENZIONE!: eseguire questi passaggi sempre prima dell'esecuzione del client o dello Script R"

1) Aprire un prompt dei comandi all'interno della cartella "..\PokémonMemory\Server"

2) Installare i moduli necessari tramite il comando "pip install -r requirements.txt"
   (ATTENZIONE!: non chiudere il prompt)

3) Aprire il file "main.py" con un editor e modificare i campi DB_HOST, DB_USER e 
   DB_PASSWORD con i dati relativi alla propria istanza del server MySQL

4) Utilizzare il prompt precedentemente aperto ed avviare il Server tramite il comando
   "python main.py"

5) Al termine dell'utilizzo dell'applicativo, interrompere l'esecuzione del Server premendo
   CTRL+C all'interno del prompt

[CLIENT]
"ATTENZIONE!: il Server dev'essere stato avviato correttamente"

- Per avviare l'interfaccia grafica di Pokémon Memory è possibile eseguire il file .exe
  presente nella cartella "..\PokémonMemory\GUIGame\GUIGame\bin\Debug" denominato "GUIGame.exe"

[SCRIPT R]
"ATTENZIONE!: il Server dev'essere stato avviato correttamente"

1) Aprire un (nuovo) prompt dei comandi all'interno della cartella "..\PokémonMemory\R Scripts"

2) Installare i moduli necessari tramite i seguenti comandi:
	" rscript -e "install.packages('httr', repos ='https://cran.mirror.garr.it/CRAN/')" "
	" rscript -e "install.packages('chron', repos ='https://cran.mirror.garr.it/CRAN/')" "

3) Eseguire lo script R per le statistiche tramite il comando "rscript UserStatistics.r" e
   seguire le indicazioni che compariranno a schermo