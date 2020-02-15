node {
    def app

    stage('Clone') {
        checkout scm
    }

    stage('Build') {
        app = docker.build("sk8m8/sk8m8-api")
    }

    stage('Push') {
        localhost
        docker.withRegistry('https://index.docker.io/v1/sk8m8/testing-repo') {
            app.push("${env.BUILD_NUMBER}")
            app.push("latest")
        }
    }
}