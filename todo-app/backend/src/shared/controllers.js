/**
 * Shared Controllers
 */

// CRUD Controller
export class CRUDController {

    constructor(service, db) {
        this.service = service;
        this.db = db;
    }
    
    create = async (req, res) => {
        try {
            const result = await this.db(client => this.service.create(client, req.body));
            res.status(201).json(result);
        } catch (error) {
            res.status(400).json({ error: error.message });
        }
    }
    
    getAll = async (req, res) => {
        try {
            const result = await this.db(client => this.service.getAll(client))
            res.status(200).send(result)
        } catch (err) {
            console.error("An error occurred:", err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }

    getByID = async (req, res) => {
        try {
            const result = await this.db(client => this.service.getByID(client, req.params.id))
            res.status(200).send(result);
        } catch (err) {
            console.error("An error occurred:", err.message || err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }

    updateFields = async (req, res) => {
        try {
            const result = await this.db(client => this.service.updateFields(client, req.body))
            res.status(200).send(result);
        } catch (err) {
            console.error("An error occurred:", err.message || err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }
    
    updateRecord = async (req, res) => {
        try {
            const result = await this.db(client => this.service.updateRecord(client, req.body))
            res.status(200).send(result);
        } catch (err) {
            console.error("An error occurred:", err.message || err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }

    deleteByID = async (req, res) => {
        try {
            const result = await this.db(client => this.service.removeByID(client, req.params.id))
            res.status(200).send(result);
        } catch (err) {
            console.error("An error occurred:", err.message || err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }
}

