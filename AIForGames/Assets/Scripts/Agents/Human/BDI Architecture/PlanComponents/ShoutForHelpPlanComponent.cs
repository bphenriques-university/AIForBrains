using UnityEngine;
using System.Collections;

public class ShoutForHelpPlanComponent : PlanComponent
{
    Human me;
    HumanSpeak.Message m;

    public ShoutForHelpPlanComponent(Human me, HumanSpeak.Message m) : base(me) {
        this.me = me;
        this.m = m;
    }

    public override bool TryExecuteAction()
    {
        me.Actuators.SendCryForHelp(m);

        return true;
    }
}
