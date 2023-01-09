# TowerDefense_Toulouse
Serious Game Rempart
Hierarchy :
	Game Manager :

		WAVE spawner 		= permet de gérer qui spawn et à quelle rythme grâce au menu déroulant.
			TimerBetweenEnemy = temps de spawn entre chaque ennemis dans la même vague 
			TimeBetweenWaves	= Temps entre chaque vague
			


		Build Manager 		= sert à rien pour toi (normalement)
		Allies spawner (lvl2) 	= permet de gérer le "Timer" de cooldown entre chaque utilisation
		Player Stats		= permet de gérer Argent et Vie de départ

	Ne pas toucher :
		-> Spawner 			= pour le moment qu'un seul point de spawn ennemis
		-> Canvas 
			-> ui_Shop		= permet de gérer le cout des tour (soldier et craftsMan ne servent plus -> cooldown)


Project :
	Prefab:			Choix puis Ouvrir le prefab pour modifier (en haut à droite)
			
		Tower:		-> Permet de modifier : Range 		= porter de tir
									Fire rate 		= plus le chiffre est PETIT plus il met de temps à tirer.
									FireCountDown 	= PAS TOUCHER
									Health 		= vie de la tour 	
									Speed Construct	= vitesse de construction
					Ne pas oublier de "Save" le préfab en haut à droite 
					Pour quitter prefab clique sur "scene" 

		Projectile : 	-> Permet de modifier : Speed			= vitesse du projectile
									Dégats		= dégat infligé à la cible 
									Slow			= premet réduire la vitesse a chaque impact la vitesse de la cible est réduit de ...   (les ennemis reste blessé indéfiniment)


		IA :			-> IA NAV Soldier:	Range 		= porter de détection des cibles. (Si dans zone de détection alors la cible perd de la vie selon les dégats).
									Init Health 	= vie 
									Care 			= (craftsman uniquement) points de vie restauré aux tours. 
									Degat 		= dégats infligé à la cible
									Fire rate		= temps avant un autre coup d'épée. Plus le chiffre est petit plus il met de temps avant un autre coup d'épée
									GoldReward 		= argent reçu (le même pour les soldats et archer pour le moment) 
					
					-> Nav Mesh Agent :	Permet de gérer la vitesse du prefab en question.
	
					-> Tower (archer): 	Health & speed construct non attribué aux archers	
