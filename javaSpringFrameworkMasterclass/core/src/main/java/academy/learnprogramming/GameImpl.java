package academy.learnprogramming;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class GameImpl implements Game {
	
	// constants
	private static final Logger log = LoggerFactory.getLogger(GameImpl.class);
	
	// fields
	private NumberGenerator numberGenerator;
	private int guessCount;
	private int number;
	private int guess;
	private int smallest;
	private int biggest;
	private int remainingGuesses;
	private boolean isValidNumberRange = true;
	
	public GameImpl(NumberGenerator numberGenerator) {
		this.numberGenerator = numberGenerator;
	}
	
	
	public int getNumber() {
		return number;
	}

	public int getGuess() {
		return guess;
	}

	public void setGuess(int guess) {
		this.guess = guess;
		
	}

	public int getSmallest() {
		return smallest;
	}

	public int getBiggest() {
		return biggest;
	}

	public int getRemainingGuesses() {
		return remainingGuesses;
	}

	public void reset() {
		smallest = 0;
		guess = 0;
		remainingGuesses = guessCount;
		biggest = numberGenerator.getMaxNumber();
		number = numberGenerator.next();
		log.debug("the number is {}", number);
	}

	public void check() {
		CheckValidNumberRange();
		
		if (isValidNumberRange) {
			if (guess > number) {
				biggest = guess - 1;
			}
			
			if (guess<number) {
				smallest = guess + 1;
			}
				
		}
		
		remainingGuesses--;
	}

	public boolean isValidNumberRange() {
		return isValidNumberRange;
	}

	public boolean isGameWon() {
		return guess == number;
	}

	public boolean isGameLost() {
		return !isGameWon() && remainingGuesses <= 0;
	}
	
	private void CheckValidNumberRange() {
		isValidNumberRange = (guess >= smallest) && (guess <= biggest);
	}

}
