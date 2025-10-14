using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public interface ISocialMedia
    {
        void PostMessage(string message);
    }

    public class FacebookService : ISocialMedia
    {
        public void PostMessage(string message) => Console.WriteLine($"Post Via Facebook: {message}");
    }

    public class TwitterService : ISocialMedia
    {
        public void PostMessage(string message) => Console.WriteLine($"Post Via Twitter: {message}");
    }

    public class SocialMediaPoster
    {
        // for multiple implementations using IEnumerable.. when using more than one service (dependencies),
        // from program , we can inject all the implementations of ISocialMedia
        // phr wo sab yahan per available ho jayein ge, or saray per kam kar sakty hain
        private readonly IEnumerable<ISocialMedia> _socialMedias;

        // The DI container automatically injects *all* ISocialMedia implementations
        public SocialMediaPoster(IEnumerable<ISocialMedia> socialMedias) // Dependency Injection via constructor
        {
            _socialMedias = socialMedias;
        }
        public void Share(string message)
        {
            foreach (var socialMedia in _socialMedias)
            {
                socialMedia.PostMessage(message);
            }
        }

        }
    }


