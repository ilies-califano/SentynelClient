﻿using SentynelAndroidClient.Animations.Base;

namespace SentynelAndroidClient.Animations;

[ContentProperty("Animations")]
public class StoryBoard : AnimationBase
{
    public List<AnimationBase> Animations { get; }

    public StoryBoard()
    {
        Animations = new();
    }

    public StoryBoard(List<AnimationBase> animations)
    {
        Animations = animations;
    }

    protected override async Task BeginAnimation()
    {
        foreach (var animation in Animations)
        {
            if (animation.Target == null)
                animation.Target = Target;

            await animation.Begin();
        }
    }

    protected override async Task ResetAnimation()
    {
        foreach (var animation in Animations)
        {
            if (animation.Target == null)
                animation.Target = Target;

            await animation.Reset();
        }
    }
}
