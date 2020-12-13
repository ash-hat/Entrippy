using System;
using ADepIn;
namespace Entrippy.Serialization
{
    public class VersionSerializer : ISerializer<Version>
    {
		private static Option<int> ComponentToOption(int component)
		{
			return component != -1 ? Option.Some(component) : Option.None<int>();
		}

		private readonly ISerializer<int> _mandatoryComponent;
		private readonly OptionSerializer<int> _optionalComponent;

		public VersionSerializer(ISerializer<int> component)
		{
			_mandatoryComponent = component;
			_optionalComponent = component.ToOption();
		}

		public Version Deserialize(IPackedReader reader)
        {
            var major = _mandatoryComponent.Deserialize(reader);
			var minor = _mandatoryComponent.Deserialize(reader);

			var build = _optionalComponent.Deserialize(reader);
			if (!build.MatchSome(out var buildInner))
			{
				return new Version(major, minor);
			}

			var revision = _optionalComponent.Deserialize(reader);
			if (!revision.MatchSome(out var revisionInner))
			{
				return new Version(major, minor, buildInner);
			}

			return new Version(major, minor, buildInner, revisionInner);
        }

        public void Serialize(IPackedWriter writer, Version value)
        {
            _mandatoryComponent.Serialize(writer, value.Major);
			_mandatoryComponent.Serialize(writer, value.Minor);
			_optionalComponent.Serialize(writer, ComponentToOption(value.Build));
			_optionalComponent.Serialize(writer, ComponentToOption(value.Revision));
        }
    }
}
