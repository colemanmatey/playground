/**
 * Shared Controllers
 */

// CRUD Controller
export class CRUDController {

    constructor(service, db) {
        this.service = service;
        this.db = db;

        // binding
        this.create = this.create.bind(this)
        this.getAll = this.getAll.bind(this)
        this.getByID = this.getByID.bind(this)
        this.updateFields = this.updateFields.bind(this)
        this.updateRecord = this.updateRecord.bind(this)
        this.deleteByID = this.deleteByID.bind(this)
    }
    
    async create(req, res, data) {
        try {
            const result = await this.db(client => this.service.create(client, data));
            res.status(201).json(result);
        } catch (error) {
            res.status(400).json({ error: error.message });
        }
    }
    
    async getAll(req, res) {
        try {
            const result = await this.db(client => this.service.getAll(client))
            res.status(200).send(result)
        } catch (err) {
            console.error("An error occurred:", err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }

    async getByID(req, res) {
        try {
            const result = await this.db(client => this.service.getByID(client, req.params.id))
            res.status(200).send(result);
        } catch (err) {
            console.error("An error occurred:", err.message || err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }

    async updateFields(req, res) {
        try {
            const result = await this.db(client => this.service.updateFields(client, req.body))
            res.status(200).send(result);
        } catch (err) {
            console.error("An error occurred:", err.message || err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }
    
    async updateRecord(req, res) {
        try {
            const result = await this.db(client => this.service.updateRecord(client, req.body))
            res.status(200).send(result);
        } catch (err) {
            console.error("An error occurred:", err.message || err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }

    async deleteByID(req, res) {
        try {
            const result = await this.db(client => this.service.removeByID(client, req.body))
            res.status(200).send(result);
        } catch (err) {
            console.error("An error occurred:", err.message || err);
            res.status(500).send({ error: "Internal Server Error" });
        }
    }
}

