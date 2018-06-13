/***********************************
// Main file of Jason JGOMAS agents
// This file can not be modified
***********************************/

// Each task has the following structure:
// task(Priority, Type, ActivatorAgent, Position, Content).
tasks([]).

// List of objects in Field Of View.
fovObjects([]).

// Aimed Agent.

aimed("false").
medicAction(on).
fieldopsAction(on).

// Indicates if agent has the flag or not.
// objectivePackTaken(on).

// Initial state in Finite State Machine.
state(standing).
current_task(nil).

// Goals

!start.

// Plans

+order(move,Ix,Iz)[source (_)]
	<-
	.print("Going up");
	?current_task(task(C_priority, _, _, _, _));
	?my_position(X,Y,Z);
	.my_name(MyName);
	!add_task(task(C_priority + 1,"TASK_GOTO_POSITION",MyName,pos(Ix,Y,Iz),""));
	-order(move,Ix,Iz)[source (_)];
	-+state(standing).


+order(up)[source (_)]
	<-
	.print("Going up");
	?current_task(task(C_priority, _, _, _, _));
	?my_position(X,Y,Z);
	.my_name(MyName);
	!add_task(task(C_priority + 1,"TASK_GOTO_POSITION",MyName,pos(X,Y,Z-10),""));
	-order(up)[source (_)];
	-+state(standing).

+order(down)[source (_)]
	<-
	.print("Going down");
	?current_task(task(C_priority, _, _, _, _));
	?my_position(X,Y,Z);
	.my_name(MyName);
	!add_task(task(C_priority + 1,"TASK_GOTO_POSITION",MyName,pos(X,Y,Z+10),""));
	-order(down)[source (_)];
	-+state(standing).

+order(left)[source (_)]
	<-
	.print("Going left");
	?current_task(task(C_priority, _, _, _, _));
	?my_position(X,Y,Z);
	.my_name(MyName);
	!add_task(task(C_priority + 1,"TASK_GOTO_POSITION",MyName,pos(X-10,Y,Z),""));
	-order(left)[source (_)];
	-+state(standing).

+order(right)[source (_)]
	<-
	.print("Going right");
	?current_task(task(C_priority, _, _, _, _));
	?my_position(X,Y,Z);
	.my_name(MyName);
	!add_task(task(C_priority + 1,"TASK_GOTO_POSITION",MyName,pos(X+10,Y,Z),""));
	-order(right)[source (_)];
	-+state(standing).

+order(ammo)[source (_)]
	<-
	.print("Going ammo");
	?current_task(task(C_priority, _, _, _, _));
	?my_position(X,Y,Z);
	.my_name(MyName);
	?my_ammo(Ar);
	if (team("AXIS")){
        .my_team("fieldops_AXIS", E1);}
    if (team("ALLIED")){
        .my_team("fieldops_ALLIED", E1);}

    .concat("cfa(",X, ", ", Y, ", ", Z, ", ", Ar, ")", Content1);
    .send_msg_with_conversation_id(E1, tell, Content1, "CFA");

	-order(ammo)[source (_)];
	-+state(standing).

+order(medical)[source (_)]
	<-
	.print("Going medical");
	?current_task(task(C_priority, _, _, _, _));
	?my_position(X,Y,Z);
	.my_name(MyName);
    ?my_health(Ar);
	if (team("AXIS")){
        .my_team("medic_AXIS", E1);}
    if (team("ALLIED")){
        .my_team("medic_ALLIED", E1);}

    .concat("cfm(",X, ", ", Y, ", ", Z, ", ", Ar, ")", Content1);
    .send_msg_with_conversation_id(E1, tell, Content1, "CFM");
    -order(medical)[source (_)];
	-+state(standing).

+order(help)[source (_)]
	<-
	.print("Going help");
	?current_task(task(C_priority, _, _, _, _));
	?my_position(X,Y,Z);
	.my_name(MyName);
	?my_health(Ar);
    if (team("AXIS")){
        .my_team("AXIS", E1);}
    if (team("ALLIED")){
        .my_team("ALLIED", E1);}

    .concat("cfh(",X, ", ", Y, ", ", Z, ", ", Ar, ")", Content1);
    .send_msg_with_conversation_id(E1, tell, Content1, "CFH");
    -order(help)[source (_)];
	-+state(standing).

+order(shot)[source (_)]
	<-
	.print("Going shot");
	!!shot(0);
    -order(shot)[source (_)];
	-+state(standing).

/*******************************
*
* Finite State Machine definition
*
*******************************/
+!fsm : state(standing)
	<- 	//operate


		?my_health(Health);
		if (Health <= 0) {
			?debug(Mode); if (Mode<=1) { .println("ESTOY MUERTO Y ME VOY AL ESTADO QUIT"); }
			-+state(quit);
			tasks([]);
			.drop_all_intentions;
			!!fsm;
			.fail;
		}

		// the user can add or eliminate targets adding or removing tasks or changing priorities
		!update_targets;

		 // if there is no tasks to do, we start again the FSM
        ?tasks(Tasks);
		.length(Tasks, TaskListLength);
		if (TaskListLength <= 0) {
                        .my_name(Myn);
                        //.println("No tengo tareas:",Myn );
			!!fsm;
			.fail;
		}


		// Obtain the task with the highest priority from Tasks list.
		if(TaskListLength > 0){
			.sort(Tasks, TasksSorted);
			.max(TasksSorted, PrioritaryTask);


			if (current_task(task(_,"TASK_WALKING_PATH",_,_,_))) {

              if (.member(task(_, "TASK_WALKING_PATH", _, _, _), TasksSorted)) {

				?task_priority("TASK_WALKING_PATH", WalkingPriority);
				PrioritaryTask = task(Priority,_,_,_,_);

				if (Priority > WalkingPriority) {

					  .delete(task(_, "TASK_WALKING_PATH", _, _, _),TasksSorted,NewTaskList);
		              -+tasks(NewTaskList);
					}
			  }
			}

			-+current_task(PrioritaryTask);
			?tasks(Tasks2);
			?debug(Mode); if (Mode<=2) { .println("LAS TAREAS SON ", Tasks2);
                                         .println("LA TAREA PRIORITARIA AHORA ES ", PrioritaryTask); }
			PrioritaryTask = task(_,_,_,CurrentDestination,_);

			-+current_destination(CurrentDestination);
			update_destination(CurrentDestination);

			-+state(go_to_target);




	    	}  else {

			    ?debug(Mode); if (Mode<=1) { .println("No tengo tareas."); }
			    ?current_destination(CurrentDestination);
			    update_destination(CurrentDestination)
			    }

        .drop_desire(fsm);
        !!fsm;
        .fail.

+!fsm : state(go_to_target)
	<-
		// Save the initial time for the first time.

		if(not initialized_time) {
			.time_in_millis(FirstCurrentTime);

			+last_time_move(FirstCurrentTime);
			+last_time_look(FirstCurrentTime);

			+initialized_time;

		}
		// Need to look?
		.time_in_millis(CurrentTime);
		?last_time_look(LastTimeLook);
		DiferentialLookTime = CurrentTime - LastTimeLook;

		if (DiferentialLookTime > 500) {
			-+last_time_look(CurrentTime);

			// Look around.
			!look;

			!perform_look_action;

			!get_agent_to_aim;


			if ((aimed(Ag)) & (Ag=="true")) {
				// Save current destination.
				?current_destination(OldDestination);

				!perform_aim_action;

				?debug(Mode); if (Mode<=2) { .println("VOY A DISPARAR!!!"); }
				// Shot.
				!!shot(0);

				// Continue to previous destination.

				update_destination(OldDestination);

				-+last_time_move(CurrentTime);

				// ya no tengo objetivo
				-+aimed("false");

			}; // End of if (aimed_agent)



		}; // Endo of if (DiferentialTime > 500)

		// Can I move?
		?last_time_move(LastTimeMove);

		DiferentialMoveTime = CurrentTime - LastTimeMove;

		if (DiferentialMoveTime < 33) {
           .wait(33);
	       .drop_desire(fsm);
			!!fsm;
			.fail;
 		}

		-+last_time_move(CurrentTime);

        if (DiferentialMoveTime > 1000) {

              move(1000);

             } else  {

                 move(DiferentialMoveTime);  }

        if (path(X ,0, Z, AgAct, Pr)) {
                 !add_task(task(Pr,"TASK_WALKING_PATH", AgAct, pos(X, 0, Z), ""));
                 -path(_,_,_,_,_);
               }

           .drop_desire(fsm);

		!!fsm;
		.fail.



+!fsm : state(target_reached) & team("AXIS") & current_task(task(_,"TASK_PATROLLING",_,_,_))
	<-
		// Task accomplished, time to delete
		?tasks(TaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>HE LLEGADO A MI PRIMER PUNTO DE PATROLLING!!!\nLA LISTA DE TAREAS ES ", TaskList); }
		?current_task(PrioritaryTask);

		.delete(PrioritaryTask,TaskList,NewTaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>ELIMINADA LA TAREA ",PrioritaryTask , " LA LISTA CONTIENE ", NewTaskList); }

        -+tasks(NewTaskList);

		?manager(M);
    	?patrollingRadius(Rad);
	    ?objective(ObjectiveX, ObjectiveY, ObjectiveZ);

    	+newPos(0,0);

        +position(invalid);
        while (position(invalid)) {
            -position(invalid);
            .random(X);
            NewObjectiveX = ObjectiveX + Rad / 2 - X * Rad;
            .random(Z);
            NewObjectiveZ = ObjectiveZ + Rad / 2 - Z * Rad;
            ?debug(Mode); if (Mode<=1) { .println("AXIS_FSM: New check position [", NewObjectiveX,", ", ObjectiveY, ", ", NewObjectiveZ,"] position."); }
            check_position(pos(NewObjectiveX, ObjectiveY, NewObjectiveZ));
            ?position(P);
            ?debug(Mode); if (Mode<=1) { .println("AXIS_FSM: position is :", P); }
            -+newPos(NewObjectiveX, NewObjectiveZ);
            }

          ?newPos(NewObjectiveX, NewObjectiveZ);

	        !add_task(task(500, "TASK_PATROLLING", M, pos(NewObjectiveX, ObjectiveY, NewObjectiveZ), ""));
  		    ?debug(Mode); if (Mode<=1) { .println("AXIS_FSM: New valid position [", NewObjectiveX,", ", ObjectiveY, ", ", NewObjectiveZ,"] position."); }

			-+state(standing);
			-position(_);

            .drop_desire(fsm);

			!!fsm;
			.fail 	.


+!fsm : state(target_reached) & current_task(task(_,"TASK_GIVE_MEDICPAKS",_,_,_)) & type("CLASS_MEDIC")
	<-
		// Task accomplished, time to delete
        // Llamar a la accion para crear paquetes de medicina
        create_medic_pack;

        ?tasks(TaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>HE LLEGADO A MI OBJETIVO!!!\nLA LISTA DE TAREAS ES ", TaskList); }
		?current_task(PrioritaryTask);

		.delete(PrioritaryTask,TaskList,NewTaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>ELIMINADA LA TAREA ",PrioritaryTask , " LA LISTA CONTIENE ", NewTaskList); }

        -+tasks(NewTaskList);

		-+state(standing);

        .drop_desire(fsm);

		!!fsm;
		.fail.


+!fsm : state(target_reached) & current_task(task(_,"TASK_GIVE_AMMOPAKS",_,_,_)) & type("CLASS_FIELDOPS")
	<-
        // Llamar a la accion para crear paquetes de armamento
        create_ammo_pack;

        // Task accomplished, time to delete
		?tasks(TaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>HE LLEGADO A MI OBJETIVO!!!\nLA LISTA DE TAREAS ES ", TaskList); }
		?current_task(PrioritaryTask);
		.delete(PrioritaryTask,TaskList,NewTaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>ELIMINADA LA TAREA ",PrioritaryTask , " LA LISTA CONTIENE ", NewTaskList); }

        -+tasks(NewTaskList);

		-+state(standing);

        .drop_desire(fsm);

		!!fsm;
		.fail.

+!fsm : state(target_reached) & current_task(task(_,"TASK_WALKING_PATH",_,_,_))
	<-
        // Task accomplished, time to delete
		?tasks(TaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>HE LLEGADO A MI OBJETIVO!!!\nLA LISTA DE TAREAS ES ", TaskList); }
		?current_task(PrioritaryTask);
		.delete(PrioritaryTask,TaskList,NewTaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>ELIMINADA LA TAREA ",PrioritaryTask , " LA LISTA CONTIENE ", NewTaskList); }

        -+tasks(NewTaskList);

         // Llamar a la accion para la siguiente tarea de la ruta
         next_path_index;
         if (path(0,0,0,_,0)) {
           -path(_,_,_,_,_);
         } else {
         	     ?path(X ,0, Z, AgAct, Pr);
                 !add_task(task(Pr, "TASK_WALKING_PATH", AgAct, pos(X, 0, Z), ""));
                 -path(_,_,_,_,_);
               }

		-+state(standing);

        .drop_desire(fsm);

		!!fsm;
		.fail.

+!fsm : state(target_reached)
	<-
		// Task accomplished, time to delete
		?tasks(TaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>HE LLEGADO A MI OBJETIVO!!!\nLA LISTA DE TAREAS ES ", TaskList); }
		?current_task(PrioritaryTask);

		.delete(PrioritaryTask,TaskList,NewTaskList);
		?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>ELIMINADA LA TAREA ",PrioritaryTask , " LA LISTA CONTIENE ", NewTaskList); }

        -+tasks(NewTaskList);

		-+state(standing);
        .drop_desire(fsm);

		!!fsm;
		.fail.

//not supported in this version
+!fsm : state(fighting).

+!fsm : state(quit)
	<- 	// END
		?debug(Mode); if (Mode<=1) { .println("It's time to go home.");	}
		.my_name(MyName);
		.drop_all_desires;
		.drop_all_events;
		.drop_all_intentions;
		.kill_agent(MyName).

-!fsm.


/*******************************
*
* Actions definitions
*
*******************************/


/////////////////////////////////
//  ADD TASK
/////////////////////////////////
+!add_task(task(TaskPriority, TaskType, ActivatorAgent, Position, Content))
    <-  ?tasks(TaskList);
        if (.member(task(_, TaskType, ActivatorAgent, _, _), TaskList)) {
            // Remove the old task
            .delete(task(_, TaskType, ActivatorAgent, _, _), TaskList, ResultList);

            // Add the new one
            .concat(ResultList, [task(TaskPriority, TaskType, ActivatorAgent, Position, Content)], NewT);
            -+tasks(NewT);

        }
        else {
            .concat(TaskList, [task(TaskPriority, TaskType, ActivatorAgent, Position, Content)], NewT);
            -+tasks(NewT);

             }.

// To add a task consulting the priority
+!add_task(task(TaskType, ActivatorAgent, Position, Content))
    <-  ?task_priority(TaskType, TaskPriority);
        !add_task(task(TaskPriority, TaskType, ActivatorAgent, Position, Content)).




/////////////////////////////////
//  END OF GAME
/////////////////////////////////
+end_of_game[source(M)]
    <-  ?debug(Mode); if (Mode<=1) { .println(M, " informs me about the end of the game."); }
        -current_task(_);
        -tasks(_);

        -+state(quit);
        .drop_all_intentions;

        !fsm.


/////////////////////////////////
//  INITIAL SETUP
/////////////////////////////////
+initial_setup(AssignedID, Map)[source(M)] : .my_name(MyName)
    <-  ?debug(Mode); if (Mode<=1) { .println(M, " assigned me the ID ", AssignedID); }
        +assigned_id(AssignedID);
        ?debug(Mode); if (Mode<=1) { .println("The selected battlefield is ", Map); }
        +battlefield(Map);
        ?debug(Mode); if (Mode<=1) { .println("Beginning to fight")}.

/////////////////////////////////
//  LOOK NEW
/////////////////////////////////
+!look : not look_response(_)
    <-

        if (waiting_look_response) {
            ?debug(Mode); if (Mode<=1) { .println("YA HE ENVIADO UNA SOLICITUD DE MIRAR"); }
            .time_in_millis(CurrentTime2);
            ?last_time_look_msg_sent(LastLookMsgSentTime);
            DiferentialTime = CurrentTime2 - LastLookMsgSentTime;
            if (DiferentialTime > 500) {
                -waiting_look_response;
                ?debug(Mode); if (Mode<=1) { .println(">>>>>>>>>>>>>>>>>>>>>>ELIMINO LA CONDICION DE ESPERA Y VUEVLO A LANZAR LOOK"); }

            }


        } else {
             // Prepare message: ask manager what is around me
            ?manager(M);
            ?assigned_id(AssignedID);
            .concat("ID: ", AssignedID, Content);


            // Send
            .send_msg_with_conversation_id(M, tell, Content, "SIGHT");

            // Timestamp
            .time_in_millis(CurrentTime2);
            +last_time_look_msg_sent(CurrentTime2);

		     ?debug(Mode); if (Mode<=1) { .println("Envio SIGHT: ", CurrentTime); }

            // Wait for response
            +waiting_look_response;

          }.


// Stop condition for look loop.
+!look : look_response(FOVObjects)
    <-  ?debug(Mode); if (Mode<=1) { .println("ACTUALIZADA LA LISTA DE OBJETOS VISTOS.")}.

-!look.


/////////////////////////////////
//  OBJECTIVE POSITION
/////////////////////////////////
+objective_position(ObjectiveX, ObjectiveY, ObjectiveZ):  manager(M) & team("ALLIED")
    <-  ?debug(Mode); if (Mode<=1) { .println("ALLIED: Objective is at [", ObjectiveX,", ", ObjectiveY, ", ", ObjectiveZ,"] position."); }
        !add_task(task(1000, "TASK_GET_OBJECTIVE", M, pos(ObjectiveX, ObjectiveY, ObjectiveZ), ""));
        +objective(ObjectiveX, ObjectiveY, ObjectiveZ);

        -+state(go_to_target).

+objective_position(ObjectiveX, ObjectiveY, ObjectiveZ):  manager(M) & team("AXIS")
    <-  ?debug(Mode); if (Mode<=2) { .println("AXIS: Objective is at [", ObjectiveX,", ", ObjectiveY, ", ", ObjectiveZ,"] position."); }
    	?patrollingRadius(Rad);
	    +objective(ObjectiveX, ObjectiveY, ObjectiveZ);

    	+newPos(0,0);

        +position(invalid);
        while (position(invalid)) {
            -position(invalid);
            .random(X);
            NewObjectiveX = ObjectiveX + Rad / 2 - X * Rad;
            .random(Z);
            NewObjectiveZ = ObjectiveZ + Rad / 2 - Z * Rad;
            ?debug(Mode); if (Mode<=2) { .println("AXIS_FSM: New check position [", NewObjectiveX,", ", ObjectiveY, ", ", NewObjectiveZ,"] position."); }
            check_position(pos(NewObjectiveX, ObjectiveY, NewObjectiveZ));
            ?position(P);
            ?debug(Mode); if (Mode<=2) { .println("AXIS_FSM: position is :", P); }
            -+newPos(NewObjectiveX, NewObjectiveZ);
            }

            ?newPos(NewObjectiveX, NewObjectiveZ);

	        !add_task(task(500, "TASK_PATROLLING", M, pos(NewObjectiveX, ObjectiveY, NewObjectiveZ), ""));
  		    ?debug(Mode); if (Mode<=2) { .println("AXIS_FSM: New valid position [", NewObjectiveX,", ", ObjectiveY, ", ", NewObjectiveZ,"] position."); }

    	    -+state(go_to_target);
    	    -position(_).




/////////////////////////////////
//  SHOOTING TO ME
/////////////////////////////////
+shooting_to_me(Bullets)[source(M)] : my_health(Health) & Health - Bullets > 0
    <-  ?my_health(Health);
        NewHealth = Health - Bullets;
        -+my_health(NewHealth);
        ?debug(Mode); if (Mode<=1) {
        	.println("HE RECIBIDO ", Bullets, " DISPAROS. Mi salud es :", NewHealth); }
        !!perform_injury_action;
        !performThresholdAction;
    	-shooting_to_me(_)[source(M)].


+shooting_to_me(Bullets)[source(M)] : my_health(Health) & Health - Bullets <= 0
    <- 	-+my_health(0);
        	-+state(quit);
        	?debug(Mode); if (Mode<=1) {
        		.println("HE RECIBIDO ", Bullets, " DISPAROS. Me muero"); }
        	!!fsm;
        	-shooting_to_me(_)[source(M)].



/////////////////////////////////
//  MEDIC_PACK TAKEN
/////////////////////////////////
+medic_pack_taken(Medicine)[source(M)]
    <-  ?my_health(Health);
        NewHealth = Health + Medicine;
        if (NewHealth > 100) { -+my_health(100); } else { -+my_health(NewHealth); }

        ?debug(Mode); if (Mode<=1) {
        	.println("HE RECIBIDO ", Medicine, " SALUD."); }
        -medic_pack_taken(_)[source(M)].


/////////////////////////////////
//  AMMO_PACK TAKEN
/////////////////////////////////
+ammo_pack_taken(Bullets)[source(M)]
    <-  ?my_ammo(Ammo);
        NewAmmo = Ammo + Bullets;
        -+my_ammo(NewAmmo);
        ?debug(Mode); if (Mode<=1) { .println("HE RECIBIDO ", Bullets, " BALAS."); }
        -ammo_pack_taken(_)[source(M)].


/////////////////////////////////
//  SHOT
/////////////////////////////////
+!shot(Shot) : my_ammo(Ammo) & Ammo > 0  // & aimed_agent(_)
			& manager(M) & assigned_id(AssignedID)
			& my_aim_threshold(AimThreshold) & my_shot_threshold(ShotThreshold)
	<- 	ShotValue = ShotThreshold - Shot;
		.concat("ID: ",AssignedID, " AIM: ", AimThreshold, " #SHOT: ", ShotValue, " ", Content);
   		.send_msg_with_conversation_id(M, tell, Content, "SHOT");
        ?debug(Mode); if (Mode<=1) { .println("ESTOY DISPARANDO."); }
   		NewAmmo = Ammo - 1;
   		-+my_ammo(NewAmmo);
   		!!performThresholdAction.

+!shot(Shot) : my_ammo(Ammo) & Ammo <= 0
	<-	?debug(Mode); if (Mode<=1) { .println("I have no ammo."); }
		!perform_no_ammo_action.

+!shot(Shot) : not aimed_agent
	<-	?debug(Mode); if (Mode<=1) { .println("No aimed enemy to shot.") }.



/////////////////////////////////
//  ATENDER PETICION CALL FOR HELP
/////////////////////////////////

+cfh(X, Y, Z, Salud)[source(M)]
    <-
        .print("Going to aid");
	?current_task(task(C_priority, _, _, _, _));

	.my_name(MyName);
	!add_task(task(C_priority + 1,"TASK_GOTO_POSITION",MyName,pos(X,Y,Z),""));
    -cfh(_)[source(_)];
     -+state(standing).












/////////////////////////////////
//  ATENDER PETICION CALL FOR MEDIC  (SOLO MEDICOS)
/////////////////////////////////

+cfm(X, Y, Z, Salud)[source(M)]
    <-
         // Soy medico y me han pedido ayuda
        !checkMedicAction;
        if (medicAction(on)) {
        					!add_task(task("TASK_GIVE_MEDICPAKS", M, pos(X, Y, Z), ""));
    					   // .send(M, tell, "cfm_agree");
                                           .concat("cfm_agree", Content);
                                           .send_msg_with_conversation_id(M, tell, Content, "CFM");
 					        -+state(standing);

        } else {

         //.send(M, tell, "cfm_refuse");
         .concat("cfm_refuse", Content);
         .send_msg_with_conversation_id(M, tell, Content, "CFM");

        }

        -cfm(_)[source(M)].


/////////////////////////////////
//  ATENDER PETICION CALL FOR AMMO  (SOLO FIELDOPS)
/////////////////////////////////

+cfa(X, Y, Z, Ammo)[source(M)]
    <-
         // Soy Fieldops y me han pedido ayuda
        !checkAmmoAction;
        if (fieldopsAction(on)) {
        					!add_task(task("TASK_GIVE_AMMOPAKS", M, pos(X, Y, Z), ""));
    					        //.send(M, tell, "cfa_agree");
                                               .concat("cfa_agree", Content);
                                               .send_msg_with_conversation_id(M, tell, Content, "CFA");

 						    -+state(standing);

        } else {

         //.send(M, tell, "cfa_refuse");
         .concat("cfm_refuse", Content);
         .send_msg_with_conversation_id(M, tell, Content, "CFA");


        }

        -cfa(_)[source(M)].




/////////////////////////////////
//  START
/////////////////////////////////
+!start : .my_name(MyName) & manager(M) & team(MyTeam) & type(MyType)
	<- 	// Setup values

        .setlogfile("agente.log");
		+my_health(100);
		+my_protection(25);
		+my_stamina(100);

		+my_ammo(100);
		+my_position(0,0,0);

		// Threshold
		+my_aim_threshold(1);
		+my_ammo_threshold(50);
		+my_health_threshold(50);
		+my_look_threshold(1);

		!setup_priorities;    // Initial priorities are set

		if (type("CLASS_SOLDIER"))  {
				+my_shot_threshold(10);
            } else { +my_shot_threshold(1); }


		?debug(Mode); if (Mode<=1) { .println("I'm ready"); }
   		.get_type(MyType,FormattedType);
   		+my_formattedType(FormattedType);
   		.get_team(MyTeam,FormattedTeam);
   		+my_formattedTeam(FormattedTeam);


   		.concat("ID: 0 Name: ", MyName, " TYPE: ", FormattedType, " TEAM: ", FormattedTeam, X);
   		.send_msg_with_conversation_id(M, tell, X, "INIT");
   		?debug(Mode); if (Mode<=1) { .println("Sent 'INIT' message to ", M); }


    	if (team("AXIS")) {

            .register( "TEAM", "AXIS");

        	if (type("CLASS_SOLDIER"))  {
				.register( "JGOMAS", "backup_AXIS");
            }

            if (type("CLASS_MEDIC")) {
					.register( "JGOMAS", "medic_AXIS");
            }

            if (type("CLASS_FIELDOPS")) {
                    .register( "JGOMAS", "fieldops_AXIS");

            }

        }

       if (team("ALLIED")) {

            .register( "TEAM", "ALLIED");

        	if (type("CLASS_SOLDIER"))  {
				.register( "JGOMAS", "backup_ALLIED");
            };

            if (type("CLASS_MEDIC")) {
					.register( "JGOMAS", "medic_ALLIED");
            };

            if (type("CLASS_FIELDOPS")) {
                    .register( "JGOMAS", "fieldops_ALLIED");

            };
		};

        .wait(2000);
        agent_setup;

        .wait(2000);

        !init;

        .wait(2000);

        -+state(standing);


        !!fsm.

//////////////////////////////
/// END OF FILE
//////////////////////////////
