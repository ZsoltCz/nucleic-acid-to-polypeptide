using System.Collections;
using NucleicAcidConverter.Enums;

namespace NucleicAcidConverter.Model;

/// <summary>
/// Represents a nucleotide sequence that can be iterated over by codons.
/// </summary>
public record Sequence : IEnumerable<string>
{
    public string NucleotideSequence { get; }

    public int ReadingFrame { get; }

    public SequenceType Type { get; }

    public Sequence(string nucleotideSequence, int readingFrame = 0)
    {
        var sequenceType = ValidateSequence(nucleotideSequence);
        if (sequenceType is null)
        {
            throw new ArgumentException("Sequence contains invalid characters");
        }

        Type = (SequenceType)sequenceType;
        NucleotideSequence = nucleotideSequence.ToUpper();
        //check for valid frame
        ReadingFrame = readingFrame;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return new SequenceEnumerator(NucleotideSequence, ReadingFrame);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private SequenceType? ValidateSequence(string sequence)
    {
        var RnaChars = new [] { 'A', 'U', 'C', 'G' };
        var DnaChars = new [] { 'A', 'T', 'C', 'G' };

        if (sequence.ToUpper().All(RnaChars.Contains))
        {
            return SequenceType.RNA;
        }
        if (sequence.ToUpper().All(DnaChars.Contains))
        {
            return SequenceType.DNA;
        }
        
        return null;
    }

    private bool ReadingFrameIsValid(int readingFrame)
    {
        return Enumerable.Range(0, 3).Contains(readingFrame);
    }
}

public class SequenceEnumerator : IEnumerator<string>
{
    private readonly string _nucleotideSequence;

    private int _index;

    private readonly int _readingFrame;

    public SequenceEnumerator(string nucleotideSequence, int readingFrame)
    {
        _nucleotideSequence = nucleotideSequence;
        _readingFrame = readingFrame;
        _index = 0;
    }

    public bool MoveNext()
    {
        if (_index * 3 + _readingFrame + 3 > _nucleotideSequence.Length)
        {
            return false;
        }
        Current = _nucleotideSequence.Substring(_index * 3 + _readingFrame, 3);
        _index += 1;
        return true;
    }

    public void Reset()
    {
        Current = _nucleotideSequence.Substring(_readingFrame, 3);
    }

    public string Current { get; private set; }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        return;
    }
}