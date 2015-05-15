using System.Collections;

public abstract class Trade{
	
	Human human;
	
	protected int points;
	public Trade(Human human, int points){
		this.human = human;
		this.points = points;
	}
	public virtual bool isFoodTrade(){
		return false;
	}
	public virtual bool isAmmoTrade(){
		return false;
	}
	public int getPoints(){
		return points;
	}
	public Human getBenefactor(){
		return human;
	}
}

public class FoodTrade : Trade{
	public FoodTrade(Human human, int points) : base(human, points){}
	public override bool isFoodTrade(){
		return true;
	}
}

public class AmmoTrade : Trade{
	public AmmoTrade(Human human, int points) : base(human, points){}
	public override bool isAmmoTrade(){
		return true;
	}
}