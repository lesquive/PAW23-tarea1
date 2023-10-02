import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import "./EditarRestaurante.css";
import axios from "axios";

function EditarRestaurante() {
  const navigate = useNavigate();
  const [restaurant, setRestaurant] = useState({
    id: "",
    nombre: "",
    dueño: "",
    provincia: "",
    cantón: "",
    distrito: "",
    direcciónExacta: "",
  });

  const restaurantId = useParams().id;

  useEffect(() => {
    axios
      .get(`https://localhost:7059/api/restaurantes/${restaurantId}`)
      .then((response) => {
        setRestaurant(response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  }, [restaurantId]);

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
      .post(
        `https://localhost:7059/api/restaurantes/${restaurant.id}`,
        restaurant
      )
      .then((response) => {
        console.log("Restaurant updated:", response.data);
      })
      .catch((error) => {
        console.error("Error updating restaurant:", error);
      });
  };

  return (
    <div className="editar-restaurante-container">
      <h2>Editar Restaurante</h2>
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
          Actualizar
        </button>
        <button className="btn" onClick={() => navigate(-1)}>
          Atras
        </button>
      </form>
    </div>
  );
}

export default EditarRestaurante;
