import { useContext } from "react";
import { DragDropContext } from "react-beautiful-dnd";
import { GameContext } from "../context/GameContext";
import DraggableFlagsContainer from "./DraggableFlagsContainer";
import EndMatchStats from "./EndMatchStats";


import SilhouettesGridContainer from "./SilhouettesGridContainer";
import Timer from "./Timer";

export default function GameApp() {
  const data = [
    {
        Name: "Nikita",
        Marks: "98",
        Phone: "123",
    },
    {
        Name: "Pratiksha",
        Marks: "96",
        Phone: "127",
    }]
    function s(){
  data.map((e)=>{alert("in s"); return <tr className="items"><td>{e.name}</td></tr>})
    }
    
  const {
    startMatch,
    setStartMatch,
    matchEnded,
    setMatch,
    handleOnDragEnd,
    matchLocation,
  } = useContext(GameContext);
  return (
    <>
      <DragDropContext onDragEnd={(result) => handleOnDragEnd(result)}>
        <main>
        
          {!startMatch ? (
            <>
              
              <img
                src={"assets/misc/globe.svg"}
                height={180}
                alt="Game Preview"
                style={{ margin: "15px 0px" }}
              />
              <button
                className="playAgainBtn"
                onClick={() => setStartMatch(true)}
              >
                
                Play
              </button>
              
            </>
          ) : matchEnded ? (
            <>
              <EndMatchStats />
              <button onClick={setMatch} className="playAgainBtn">
                Play again
              </button>
              
            </>
          ) : (
            <>
              <figure className="locationBox">
                <h1>Location:</h1>
                <p>{matchLocation}</p>
              </figure>

              <section className="gameplaySection">
                <SilhouettesGridContainer />
                <aside>
                  <Timer />
                  <DraggableFlagsContainer />
                </aside>
              </section>
              
              
            </>
          )}
        </main>
      </DragDropContext>
    </>
  );
}
