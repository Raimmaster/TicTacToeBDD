
Feature: TIC-TAC-TOE

Scenario: Start a new game
	When I start the match
	Then both players should be asked for their names

Scenario: Choose player one
	Given 'Ricardo' and 'Luis' are player one and two 
	Then one will be chosen randomly to be player one

Scenario: Choose symbols for players
	Given 'Ricardo' and 'Luis' are both players
	Then one will be chosen randomly to use symbol X or 0

Scenario: Choose empty slot
	Given the next board
	| sandunga1| sandunga2     | sandunga3 |
	| X        | X             |           | 
	| X        | 0             |           |
	| 0        | 0             | X         | 
	When a players picks row 1 and column 2
	Then it should be a valid move
	And other player picks row 0 and columns 1
	Then it should be an invalid move

Scenario: Validate game victory
	Given the next board
	| sandunga1| sandunga2     | sandunga3 |
	| X        | X             | X         | 
	| X        | 0             |           |
	| 0        | 0             | X         | 
	Then Player X has won the match
	And victory should be written to the file

Scenario: Validate draw game
	Given the next board
	| sandunga1| sandunga2     | sandunga3 |
	| 0        | 0             | X         | 
	| X        | X             | 0         |
	| 0        | 0             | X         | 
	Then the match is drawed
	And nothing should be written

Scenario: Show ranking table
	Given the follow game table
	| PlayerName |
	| Ricardo    |
	| Kevin      |
	| Luis       |
	| Ricardo    |
	| Jacobo     |
	| Nexer      |
	| Jacobo     |
	| Maynor     |
	| Ricardo    |
	| Ricardo    |
	| Luis       |
	| Luis       |
	| Kevin      |
	| Rafael     |
	| Brandom    |
	Then the ranking table should look like
	| Position | PlayerName | MatchWon |
	| 1        | Ricardo    | 4        |
	| 2        | Luis       | 3        |
	| 3        | Kevin      | 2        |
	| 4        | Jacobo     | 2        |
	| 5        | Nexer      | 1        |
0
