pipeline {

    agent any

    stages {
        stage('Build') {
            steps {
                sh 'docker image build -t myapp:1.0 .'
                sh 'docker image build --target testrunner -t myapp:test .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker container run myapp:test'
            }
        }
        stage('Deploy') {
            steps {
                sh 'docker container run myapp:1.0'
            }
        }
    }
}
