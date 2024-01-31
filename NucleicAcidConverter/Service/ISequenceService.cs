using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Service;

public interface ISequenceService
{
    public Sequence CreateSequence(SequenceDto sequenceDto);
}