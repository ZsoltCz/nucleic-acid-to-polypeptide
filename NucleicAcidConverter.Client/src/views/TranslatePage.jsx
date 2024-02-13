import { useState } from "react";
import SequenceForm from "../components/SequenceForm";
import ResultDisplay from "../components/ResultDisplay";
import { CircularProgress } from "@mui/material";

export default function TranslatePage() {
  const [translationResult, setTranslationResult] = useState([]);
  const [displayedProperty, setDisplayedProperty] = useState("name");
  const [loading, setLoading] = useState(false);

  return (
    <>
      <SequenceForm
        setTranslationResult={setTranslationResult}
        displayedProperty={displayedProperty}
        setDisplayedProperty={setDisplayedProperty}
        setLoading={setLoading}
      />
      {loading ? (
        <CircularProgress />
      ) : (
        <ResultDisplay
          translationResult={translationResult}
          displayedProperty={displayedProperty}
        />
      )}
    </>
  );
}
