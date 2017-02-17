
Feature: TIC-TAC-TOE

Scenario: Start a new game
	Given 'Raim' and 'Nick'
	When I start the match
	Then both players should be asked for their names

Scenario: Choose player one
	Given 'Raim' and 'Nick' are player one and two 
	Then one will be chosen randomly to be player one

Scenario: Choose symbols for players
	Given 'Raim' and 'Nick' are both players
	Then one will be chosen randomly to use symbol X or 0

Scenario: Choose empty slot
	Given the next board
	|C0 |C1 |C2 |
	| X | X |   | 
	| X | 0 |   |
	| 0 | 0 | X | 
	When a players picks row 1 and column 2
	Then it should be a valid move
	And other player picks row 0 and columns 1
	Then it should be an invalid move

Scenario: Validate game victory
	Given this next board
	|C0 |C1 |C2 |
	| X | X | X | 
	| X | 0 |   |
	| 0 | 0 | X |
	Then Player 'X' has won the match
	And victory should be written to the file

Scenario: Validate draw game
	Given this next full board
	|C0 |C1 |C2 |
	| X | 0 | 0 | 
	| 0 | X | X |
	| 0 | X | 0 |
	Then the match is drawed
	And nothing should be written

Scenario: Show ranking table
	Given the follow game table
	| PlayerName |
	| Raim		|
	| Nick      |
	| Isaula    |
	| Raim		|
	| Jacobo    |
	| Nexer     |
	| Jacobo    |
	| Lucas     |
	| Raim		|
	| Raim		|
	| Isaula    |
	| Isaula    |
	| Nick      |
	| Rafael    |
	| Daniel    |
	Then the ranking table should look like
	| Position | PlayerName | MatchesWon |
	| 1        | Raim		| 4			 |
	| 2        | Isaula     | 3			 |
	| 3        | Nick       | 2			 |
	| 4        | Jacobo     | 2			 |
	| 5        | Nexer      | 1			 |

