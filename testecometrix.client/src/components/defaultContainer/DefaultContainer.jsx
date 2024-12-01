import "../../css/Custom.css";
import Header from "../header/Header";

function DefaultContainer({children}) {
  
    return (
        <div className="container-default">
           <Header/>
           <div className="dv-principal">
            {children}
           </div>
        </div>
    );
}
  
export default DefaultContainer;