Item pickup scripts from https://www.patrykgalach.com/2020/03/16/pick-up-items-in-unity/
Player movement and networking scripts from networking tutorial

Team members: Afeef Akhtar, Aaron Willming, Ember Vaingloria

Player Interaction Pattern: Team Competition

Objective: Capture
 
Serious Objective: Get the players to understand the potential impact of data packet loss, especially across network connections.

Procedures:
Pick up packet of data
Throw down packet
Steal packet from nearby player

Rules:
Light 3d map with vertical segments, arranged to fit the model of the interior of a computer.

Resources:
Packets of information that can only score for one side or the other

Non-plain-vanilla procedure/rule (see the Hw02 handout for what would qualify as an unusual procedure/rule):
You can only jump while not holding a packet - your mobility is impacted by your state, so throwing matters more

Serious Question:
How would you ensure data packets are not lost in transmission? (Be creative!)

Answer:
This question is intentionally open-ended, but at base the answer we would expect peoplee to consider is some form of marking system to denote packets that are necessary to transmit so everything is bundled together, and checks on the receiving end to ensure they received all data packets.
