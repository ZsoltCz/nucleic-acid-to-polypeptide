import { useState } from "react";
import SequenceForm from "../components/SequenceForm";
import ResultDisplay from "../components/ResultDisplay";


export default function TranslatePage() {

  const [translationResult, setTranslationResult] = useState([]);
  const [displayedProperty, setDisplayedProperty] = useState("name");

  return (
    <>
      <SequenceForm setTranslationResult={setTranslationResult} displayedProperty={displayedProperty} setDisplayedProperty={setDisplayedProperty} />
      <ResultDisplay translationResult={translationResult} displayedProperty={displayedProperty} />
    </>
  );
};