node {
    def app

    stage('Clone') {
        checkout scm
    }

    stage('Build') {
        app = docker.build("sk8m8-api")
    }

    stage('Push') {
        app.push("latest")
    }
}