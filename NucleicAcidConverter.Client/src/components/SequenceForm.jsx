import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";
import { useState } from "react";

const serverUrl = import.meta.env.VITE_SERVER_URL;
const readingFrames = [0, 1, 2];

export default function SequenceForm({ setTranslationResult, displayedProperty, setDisplayedProperty, setLoading }) {

  const [sequence, setSequence] = useState({
    nucleotideSequence: "",
    readingFrame: 0
  });

  const handleSequenceChange = (event) => {
    setSequence(prevSequence => {
      return {
        ...prevSequence,
        [event.target.name]: event.target.value
      };
    });
  };

  const handleDisplayChange = (event) => {
    setDisplayedProperty(event.target.value);
  };

  const formStyleTemp = {
    marginTop: "20px"
  }

  const fetchWithTimeout = async (url, timeout = 8000) => {
    const controller = new AbortController();
    const id = setTimeout(() => controller.abort(), timeout);

    try {
      const response = await fetch(url);
      clearTimeout(id);
      if (!response.ok) {
        const message = await response.text();
        throw new Error(message);
      }
      const data = await response.json();
      return data;
    } catch (error) {
      clearTimeout(id);
      throw error;
    };
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);
    try {
      const aminoAcids = await fetchWithTimeout(`${serverUrl}/translate?NucleotideSequence=${sequence.nucleotideSequence}&ReadingFrame=${sequence.readingFrame}`);
      setLoading(false);
      setTranslationResult(aminoAcids);
    } catch (error) {
      setTranslationResult([]);
      setLoading(false);
      console.error(error);
    };
  };

  return (
    <form style={formStyleTemp} onSubmit={handleSubmit}>
      <FormControl>
        <TextField
          label="DNA or RNA sequence"
          id="nucleotide-sequence"
          required
          multiline
          rows="4"
          name="nucleotideSequence"
          onChange={handleSequenceChange}
          value={sequence.nucleotideSequence}
        />
      </FormControl>
      <FormControl>
        <InputLabel id="reading-frame-label">Reading frame</InputLabel>
        <Select
          labelId="reading-frame-label"
          value={sequence.readingFrame}
          label="Reading frame"
          name="readingFrame"
          onChange={handleSequenceChange}
        >
          {readingFrames.map((readingFrame) => (
            <MenuItem key={readingFrame} value={readingFrame}>
              {readingFrame + 1}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
      <FormControl>
        <InputLabel id="displayed-property-label">
          Amino acid display
        </InputLabel>
        <Select
          value={displayedProperty}
          labelId="displayed-property-label"
          onChange={handleDisplayChange}
        >
          <MenuItem value="name">Name</MenuItem>
          <MenuItem value="threeLetterSymbol">Three letter symbol</MenuItem>
          <MenuItem value="oneLetterSymbol">One letter symbol</MenuItem>
        </Select>
      </FormControl>
      <FormControl>
        <Button type="submit" variant="outlined">
          Translate
        </Button>
      </FormControl>
    </form>
  );
};
