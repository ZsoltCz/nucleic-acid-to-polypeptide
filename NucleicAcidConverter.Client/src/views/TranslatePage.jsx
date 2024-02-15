import { useState } from "react";
import SequenceForm from "../components/SequenceForm";
import ResultDisplay from "../components/ResultDisplay";

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
      <ResultDisplay
        displayedProperty={displayedProperty}
        loading={loading}
        translationResult={translationResult}
      />
    </>
  );
}
