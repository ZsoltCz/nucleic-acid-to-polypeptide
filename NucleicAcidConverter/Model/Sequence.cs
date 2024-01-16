using System.Collections;

namespace NucleicAcidConverter.Model;

/// <summary>
/// Represents a nucleotide sequence that can be iterated over by codons.
/// </summary>
public record Sequence : IEnumerable<string>
{
    private readonly string _nucleotideSequence;

    private readonly int _readingFrame;

    public Sequence(string nucleotideSequence, int readingFrame)
    {
        _nucleotideSequence = nucleotideSequence;
        //check for valid frame
        _readingFrame = readingFrame;
    }


    public IEnumerator<string> GetEnumerator()
    {
        return new SequenceEnumerator(_nucleotideSequence, _readingFrame);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
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