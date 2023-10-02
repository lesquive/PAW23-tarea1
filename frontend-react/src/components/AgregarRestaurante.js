import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./AgregarRestaurante.css";
import axios from "axios";

function AgregarRestaurante() {
  const navigate = useNavigate();
  const [restaurant, setRestaurant] = useState({
    nombre: "",
    dueño: "",
    provincia: "",
    cantón: "",
    distrito: "",
    direcciónExacta: "",
  });

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setRestaurant({
      ...restaurant,
      [name]: value,
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    axios
      .post("https://localhost:7059/api/restaurantes", restaurant)
      .then((response) => {
        console.log("Nuevo restaurante creado:", response.data);
        navigate("/"); // Redirect to the list of restaurantes
      })
      .catch((error) => {
        console.error("Error al crear restaurante:", error);
      });
  };

  return (
    <div className="agregar-restaurante-container">
      <h2>Agregar Nuevo Restaurante</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Nombre:</label>
          <input
            type="text"
            name="nombre"
            value={restaurant.nombre}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-group">
          <label>Dueño:</label>
          <input
            type="text"
            name="dueño"
            value={restaurant.dueño}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-group">
          <label>Provincia:</label>
          <input
            type="text"
            name="provincia"
            value={restaurant.provincia}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-group">
          <label>Cantón:</label>
          <input
            type="text"
            name="cantón"
            value={restaurant.cantón}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-group">
          <label>Distrito:</label>
          <input
            type="text"
            name="distrito"
            value={restaurant.distrito}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-group">
          <label>Dirección Exacta:</label>
          <input
            type="text"
            name="direcciónExacta"
            value={restaurant.direcciónExacta}
            onChange={handleInputChange}
          />
        </div>
        <button type="submit" className="btn">
          Agregar
        </button>
        <button className="btn" onClick={() => navigate("/restaurantes")}>
          Atrás
        </button>
      </form>
    </div>
  );
}

export default AgregarRestaurante;
